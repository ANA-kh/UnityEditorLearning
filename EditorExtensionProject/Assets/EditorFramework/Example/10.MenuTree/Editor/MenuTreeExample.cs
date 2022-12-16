using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(10)]
    public class MenuTreeExample : EditorWindow
    {
        private MenuTree _tree;

        private void OnEnable()
        {
            _tree = new MenuTree();
            _tree.onCurrentChange += TreeOnonCurrentChange;
            _tree.ReadTree(new List<string>()
            {
                "1",
                "1/1/1",
                "1/1/2",
                "1/1/4",
                "1/1/5",
                "1/2/1",
                "1/3/1",
                "1/4/1",
                "2",
                "2/1/1",
                "2/1/2",
                "2/1/4",
                "2/1/5",
                "2/2/1",
                "2/3/1",
                "2/4/1",
            });
        }

        private void TreeOnonCurrentChange(string obj)
        {
            Debug.Log("Select " + obj);
        }

        private void OnGUI()
        {
            _tree.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(400),GUILayout.Width(200)));
        }
    }
}