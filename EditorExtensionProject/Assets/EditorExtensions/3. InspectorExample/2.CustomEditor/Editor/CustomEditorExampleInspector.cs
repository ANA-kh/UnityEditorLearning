using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditor(typeof(CustomEditorExample))]
    public class CustomEditorExampleInspector : Editor
    {
        CustomEditorExample Target
        {
            get { return target as CustomEditorExample; }//target : The object being inspected.
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var hpRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(hpRect,Target.Hp, "Hp");
            var rangeRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rangeRect, Target.Range, "Range");
            
            Target.RoleName = EditorGUILayout.TextField("RoleName", Target.RoleName);
            
            EditorGUILayout.ObjectField(serializedObject.FindProperty("OtherObj"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}