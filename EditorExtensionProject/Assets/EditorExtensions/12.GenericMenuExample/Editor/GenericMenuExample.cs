using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// https://docs.unity.cn/cn/current/ScriptReference/GenericMenu.html
    /// </summary>
    public class GenericMenuExample : EditorWindow
    {
        [MenuItem("EditorExtensions/08.GenericMenu/Open")]
        static void Open()
        {
            GetWindow<GenericMenuExample>().Show();
        }

        private void OnGUI()
        {
            var e = Event.current;
            if (e.type == EventType.MouseDown && e.button == 1)
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Item1"), false, () => { Debug.Log("Item1"); });
                menu.AddItem(new GUIContent("Items/Item2"), false, () => { Debug.Log("Item2"); });
                menu.AddItem(new GUIContent("Items/Item3"), false, () => { Debug.Log("Item3"); });
                menu.AddSeparator("Items/");
                menu.AddItem(new GUIContent("Items/Item4"), false, () => { Debug.Log("Item4"); });
                menu.ShowAsContext();
                e.Use();
            }
        }
    }
}