using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        private IEnumerable<Type> _editorWindowTypes;
        private Vector2 _scrollPosition;
        private IEnumerable<Type> _customEditorWindowTypes;

        [MenuItem("EditorFramework/Open %#E")]
        static void Open()
        {
            GetWindow<RootWindow>();
        }

        private void OnEnable()
        {
            var editorWindowType = typeof(EditorWindow);
            //var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.NonPublic | BindingFlags.Instance);

            _editorWindowTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(editorWindowType));
            _customEditorWindowTypes = _editorWindowTypes.Where(type =>
                type.GetCustomAttribute(typeof(CustomEditorWindowAttribute), true) != null);
        }

        private void OnGUI()
        {
            foreach (var customEditorWindowType in _customEditorWindowTypes)
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(customEditorWindowType.Name);
                    if (GUILayout.Button("Open", GUILayout.Width(100)))
                    {
                        GetWindow(customEditorWindowType).Show();
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(5));
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            foreach (var editorWindowType in _editorWindowTypes)
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(editorWindowType.Name);
                    if (GUILayout.Button("Open", GUILayout.Width(100)))
                    {
                        GetWindow(editorWindowType).Show();
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
    }
}