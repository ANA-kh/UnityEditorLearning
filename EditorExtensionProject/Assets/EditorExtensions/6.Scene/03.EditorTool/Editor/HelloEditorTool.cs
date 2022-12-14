using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtensions
{
    [EditorTool("Hello EditorTool")]
    public class HelloEditorTool : EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            window.ShowNotification(new GUIContent("Hello EditorTool"));
            
            Handles.BeginGUI();
            if (GUILayout.Button("Hello EditorTool"))
            {
                Debug.Log("Hello EditorTool");
            }
            Handles.EndGUI();
        }
    }
}
