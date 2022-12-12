using System;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace EditorExtensions
{
    /// <summary>
    /// https://docs.unity.cn/cn/current/ScriptReference/EditorGUILayout.html
    /// https://docs.unity3d.com/2021.3/Documentation/ScriptReference/EditorGUILayout.html
    /// </summary>
    public class EditorGUILayoutAPI
    {
        private BuildTargetGroup _selectedBuildTargetGroup;
        private readonly AnimBool _openFadeGroup = new AnimBool();
        private bool _foldoutGroup = true;
        private bool _toggleGroup = true;
        private bool _toggle1 = true;
        private bool _toggle2 = false;
        private bool _toggle3 = true;

        public void Draw()
        {
            _foldoutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(_foldoutGroup, "Foldout Header Group");
            if (_foldoutGroup)
            {
                _openFadeGroup.target = EditorGUILayout.ToggleLeft("open Fade Group", _openFadeGroup.target);
                EditorGUILayout.BeginFadeGroup(_openFadeGroup.faded);
                if(_openFadeGroup.target)
                {
                    _selectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
                    if (_selectedBuildTargetGroup == BuildTargetGroup.Android)
                    {
                        EditorGUILayout.LabelField("Android specific things");
                    }

                    if (_selectedBuildTargetGroup == BuildTargetGroup.Standalone)
                    {
                        EditorGUILayout.LabelField("Standalone specific things");
                    }
                    EditorGUILayout.EndBuildTargetSelectionGrouping();
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            
            _toggleGroup = EditorGUILayout.BeginToggleGroup("Toggle Group", _toggleGroup);
            if (_toggleGroup)
            {
                _toggle1 = EditorGUILayout.Toggle("Toggle 1", _toggle1);
                _toggle2 = EditorGUILayout.Toggle("Toggle 2", _toggle2);
                _toggle3 = EditorGUILayout.Toggle("Toggle 3", _toggle3);
            }
            EditorGUILayout.EndToggleGroup();
        }
    }
}