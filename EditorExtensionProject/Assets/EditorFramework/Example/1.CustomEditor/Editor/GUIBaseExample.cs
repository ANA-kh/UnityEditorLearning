using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow]
    public class GUIBaseExample: EditorWindow
    {
        public class Label : GUIBase
        {
            private string _text;

            public Label(string text)
            {
                _text = text;
            }
            
            public override void OnGUI(Rect position)
            {
                GUILayout.Label(_text);
            }

            protected override void OnDispose()
            {
                _text = null;
            }
        }
        
        private GUIBase _label = new Label("123");
        private GUIBase _label2 = new Label("456");
        private void OnGUI()
        {
            _label.OnGUI(default);
            _label2.OnGUI(default);
        }
    }
}