using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EditorExtensions
{
    public class ReorderableListExample : EditorWindow
    {
        [MenuItem("EditorExtensions/06.ReorderableList/Open")]
        public static void Open()
        {
            GetWindow<ReorderableListExample>().Show();
        }

        private ReorderableList _list;
        private List<Vector2> _data = new List<Vector2>();

        private void OnEnable()
        {
            _list = new ReorderableList(_data, typeof(Vector2));
            _list.elementHeight = 30;
            _list.drawHeaderCallback += DrawHeader;
            _list.drawNoneElementCallback += DrawNoneElement;
            _list.drawElementCallback += DrawElement;
            _list.drawElementBackgroundCallback += DrawElementBackground;
        }

        private void DrawElementBackground(Rect rect, int index, bool isactive, bool isfocused)
        {
            GUI.DrawTexture(rect,Texture2D.whiteTexture);
        }

        private void DrawElement(Rect rect, int index, bool isactive, bool isfocused)
        {
            _data[index] = EditorGUI.Vector2Field(rect, "", _data[index]);
        }

        private void DrawNoneElement(Rect rect) { }

        private void DrawHeader(Rect rect)
        {
            GUI.Box(rect,"Header");
        }

        private void OnGUI()
        {
            _list.DoLayoutList();
        }
    }
}