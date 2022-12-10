using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example._1.CustomEditor.Editor
{
    [CustomEditorWindow]
    public class CustomEditorExample: EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("This is a Custom Editor Window");
        }
    }
}