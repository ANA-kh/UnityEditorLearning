using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(8)]
    public class SearchFieldExample : EditorWindow
    {
        private SearchField _searchField;

        private string _searchContent = "";
        private string[] _searchableContents = new string[]
            { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5" };

        private void OnEnable()
        {
            _searchField = new SearchField(_searchContent, _searchableContents, 0);
            _searchField.OnModeChanged += OnModeChanged;
            _searchField.OnValueChanged += OnValueChanged;
            _searchField.OnEndEdit += OnEndEdit;
        }

        private void OnEndEdit(string obj)
        {
            Debug.Log(obj);
        }

        private void OnValueChanged(string obj)
        {
            Debug.Log(obj);
        }

        private void OnModeChanged(int obj)
        {
            Debug.Log(obj);
        }

        private void OnGUI()
        {
            GUILayout.Label("SearchFiled");
            _searchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    }
}