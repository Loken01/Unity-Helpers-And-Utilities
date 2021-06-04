using UnityEngine;

/* 
 * Author: 	Noel Watters
 * Date:	04/06/2021
 */

namespace UnityEditor
{
    /// <summary>
    /// Handles drawing a field with a toggle attribute
    /// </summary>
    [CustomPropertyDrawer(typeof(ToggleAttribute))]
    public class ToggleDrawer : PropertyDrawer
    {
        /// <summary>The height to add if the warning box is present</summary>
        private static float WarningBoxHeight = 20;
        /// <summary>The offset to add to the warning box if it is present</summary>
        private static float WarningBoxOffset = 2;

        /// <summary>
        /// Attempts to find and return the serialized property the toggle attribute is referencing
        /// </summary>
        private SerializedProperty GetToggleProperty(SerializedProperty property)
        {
            // First get the attribute since it contains the range for the slider
            ToggleAttribute toggle = attribute as ToggleAttribute;
            SerializedProperty toggleProp = property.serializedObject.FindProperty(property.propertyPath.Replace(property.name, toggle.ToggleName));
            return toggleProp;
        }

        /// <summary>
        /// Returns whether or not a given property should be visible based on the attached toggle attribute
        /// </summary>
        private bool ShouldDisplay(SerializedProperty property)
        {
            // First get the attribute since it contains the range for the slider
            ToggleAttribute toggle = attribute as ToggleAttribute;

            bool Display = true;
            SerializedProperty toggleProp = GetToggleProperty(property);
            if (toggleProp != null && toggleProp.propertyType == SerializedPropertyType.Boolean)
            {
                if (toggle.Invert)
                    Display = !toggleProp.boolValue;
                else
                    Display = toggleProp.boolValue;
            }

            return Display;
        }

        /// <summary>
        /// Draws the property inside the given rect
        /// </summary>
        /// <param name="position">The rect to draw within</param>
        /// <param name="property">The property to draw</param>
        /// <param name="label">The beautified property name</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //If the toggle attributes target property is null
            if (GetToggleProperty(property) == null)
            {
                //First get the attribute since it contains the range for the slider
                ToggleAttribute toggle = attribute as ToggleAttribute;
                //Display an error
                EditorGUI.HelpBox(new Rect(position.x, position.y, position.width, WarningBoxHeight), "Toggle: No bool found matching \"" + toggle.ToggleName + "\" on the same level", MessageType.Warning);
                //Draw the property as normal
                EditorGUI.PropertyField(new Rect(position.x, position.y + WarningBoxHeight + WarningBoxOffset, position.width, position.height - WarningBoxHeight), property, label, true);
            }
            //Otherwise, only display the property if the toggle attribute allows it
            else if (ShouldDisplay(property))
                EditorGUI.PropertyField(position, property, label, true);
        }

        /// <summary>
        /// Returns the height of the given property and label
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //If the toggle attributes target property is null
            if (GetToggleProperty(property) == null)
                //Return the height, along with additional height for the warning box
                return EditorGUI.GetPropertyHeight(property, label) + WarningBoxHeight + WarningBoxOffset;
            
            //Otherwise, if the property should be visible
            if (ShouldDisplay(property))
                //Return the standard height
                return EditorGUI.GetPropertyHeight(property, label);
            
            //Otherwise, make the property tiny (A small negative value makes the inspector look as if no property was ever there)
            return -2;
        }
    }
}