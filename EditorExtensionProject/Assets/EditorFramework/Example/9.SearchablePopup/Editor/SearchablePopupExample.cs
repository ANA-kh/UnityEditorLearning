using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(9)]
    public class SearchablePopupExample : EditorWindow
    {
        private DayOfWeek _value;
        
        private void OnGUI()
        {
            EditorGUILayout.EnumPopup("DayOfWeek", _value);
            var rect = GUILayoutUtility.GetRect(200, 200);
            if (GUI.Button(rect, "Change\nthe\nDayOfWeek"))
            {
                SearchablePopup.Show(rect,Enum.GetNames(typeof(DayOfWeek)),(int)_value,OnValueChange);
            }

        }

        private void OnValueChange(int arg1, string arg2)
        {
            _value = (DayOfWeek)arg1;
            Repaint();
        }
    }
}