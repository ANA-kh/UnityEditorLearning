using UnityEngine;

namespace EditorExtensions
{
    public class GetLastRectExample : MonoBehaviour
    {
        void OnGUI()
        {
            GUILayout.Button("My button");
            if (Event.current.type == EventType.Repaint &&
                GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
            {
                GUILayout.Label("Mouse over!");
            }
            else
            {
                GUILayout.Label("Mouse somewhere else");
            }
        }
    }
}