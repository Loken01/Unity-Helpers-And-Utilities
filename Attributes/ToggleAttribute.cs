/* 
 * Author: 	Noel Watters
 * Date:	04/06/2021
 */

namespace UnityEngine
{
    /// <summary>
    /// Toggles the visibility of an inspector field based on the boolean value of another named field
    /// </summary>
    public class ToggleAttribute : PropertyAttribute
    {
        /// <summary>The name of the boolean field to look for</summary>
        public string ToggleName;
        /// <summary>If true, then the toggled field will only be visible when the named field is false</summary>
        public bool Invert = false;

        public ToggleAttribute(string ToggleName, bool Invert = false)
        {
            this.ToggleName = ToggleName;
            this.Invert = Invert;
        }
    }
}