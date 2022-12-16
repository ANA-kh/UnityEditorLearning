using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private FolderField _folderField;

        private void OnEnable()
        {
            _folderField = new FolderField();
        }

        private void OnGUI()
        {
            GUILayout.Label("Folder Field");
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            _folderField.OnGUI(rect);
        }
    }
}