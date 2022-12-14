using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class PopupWindowExample : EditorWindow
    {
        private Rect _lastRect;

        [MenuItem("EditorExtensions/09.PopupWindow/Open")]
        public static void Open()
        {
            GetWindow<PopupWindowExample>();
        }

        private void OnGUI()
        {
            
            if (GUILayout.Button("Open Popup",GUILayout.Width(200)))
            {
                PopupWindow.Show(_lastRect, new PopupWindowContentExample());
            }
            
            if (Event.current.type == EventType.Repaint)
            {
                _lastRect = GUILayoutUtility.GetLastRect();
            }
        }

        public class PopupWindowContentExample : PopupWindowContent
        {
            private bool _toggle1 = false;
            private bool _toggle2 = false;
            private bool _toggle3 = true;

            public override void OnGUI(Rect rect)
            {
                EditorGUILayout.LabelField("Popup Window Example", EditorStyles.boldLabel);
                _toggle1 = EditorGUILayout.Toggle("Toggle 1", _toggle1);
                _toggle2 = EditorGUILayout.Toggle("Toggle 2", _toggle2);
                _toggle3 = EditorGUILayout.Toggle("Toggle 3", _toggle3);
            }

            public override Vector2 GetWindowSize()
            {
                return new Vector2(200, 200);
            }

            public override void OnOpen()
            {
                Debug.Log("PopupWindowContentExample.OnOpen");
            }

            public override void OnClose()
            {
                Debug.Log("PopupWindowContentExample.OnClose");
            }
        }
    }
}