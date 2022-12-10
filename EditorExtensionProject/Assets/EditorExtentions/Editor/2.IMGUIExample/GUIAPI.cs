using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {
        private Rect _labelRect = new Rect(10, 90, 100, 20);
        private Rect _buttonRect = new Rect(10, 120, 100, 20);
        private Rect _textFieldRect = new Rect(10, 150, 100, 20);
        private Rect _textAreaRect = new Rect(10, 180, 100, 20);
        private string _textFieldValue;
        private string _textAreaValue;

        public void Draw()
        {
            GUI.Label(_labelRect, "Label");
            if (GUI.Button(_buttonRect, "Button"))
            {
                Debug.Log("Button Click");
            }
            _textFieldValue = GUI.TextField(_textFieldRect, _textFieldValue);
            _textAreaValue = GUI.TextArea(_textAreaRect, _textAreaValue);
        }
    }
}