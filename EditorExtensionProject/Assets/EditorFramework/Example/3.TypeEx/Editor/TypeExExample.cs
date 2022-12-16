using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    /// <summary>
    /// Type反射操作例子
    /// </summary>
    [CustomEditorWindow(3)]
    public class TypeExExample : EditorWindow
    {
        private IEnumerable<Type> _exampleTypes;
        private IEnumerable<Type> _exampleTypesWithExampleAttr;

        private class Example
        {
            public virtual string Name { get; }
        }
        [Example("Type A")]
        private class ExampleA : Example
        {
            public override string Name { get; } = "ExampleA";
        }
        [Example("Type B")]
        private class ExampleB : Example
        {
            public override string Name { get; } = "ExampleB";
        }
        private class ExampleAttribute : Attribute
        {
            public string Type;
            public ExampleAttribute(string type = "")
            {
                Type = type;
            }
        }

        private void OnEnable()
        {
            _exampleTypes = typeof(Example).GetSubTypesInAssemblies();
            _exampleTypesWithExampleAttr = typeof(Example).GetSubTypesWithClassAttributeInAssemblies<ExampleAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("Types");
            foreach (var exampleType in _exampleTypes)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(exampleType.Name);
                GUILayout.EndHorizontal();
            }

            GUILayout.Label("Types with ExampleAttribute");
            foreach (var type in _exampleTypesWithExampleAttr)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(type.Name);
                GUILayout.Label(type.GetCustomAttribute<ExampleAttribute>().Type);
                GUILayout.EndHorizontal();
            }
        }
    }
}