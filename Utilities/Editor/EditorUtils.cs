using UnityEngine;

/* 
 * Author: 	Noel Watters
 * Date:	04/06/2021
 */

namespace UnityEditor
{
    public static class EditorUtils
    {
        /// <summary>
        /// Creates a new gameObject with all necessary components for the given type
        /// </summary>
        public static void Create<T>(string name)
        {
            GameObject newGO = new GameObject(name, typeof(T));
            if (Selection.activeGameObject != null)
            {
                newGO.transform.SetParent(Selection.activeGameObject.transform);
                newGO.transform.localPosition = Vector3.zero;
                newGO.transform.localRotation = Quaternion.identity;
                newGO.transform.localScale = Vector3.one;
                if (Selection.activeGameObject.GetComponent<RectTransform>() != null)
                    newGO.AddComponent<RectTransform>();
            }
            else
            {
                newGO.transform.localPosition = Vector3.zero;
                if (SceneView.lastActiveSceneView != null)
                    newGO.transform.position = SceneView.lastActiveSceneView.pivot;
                newGO.transform.localRotation = Quaternion.identity;
                newGO.transform.localScale = Vector3.one;
            }

            Selection.activeGameObject = newGO;
            Undo.RegisterCreatedObjectUndo(newGO, "Created " + name);
        }
    }
}