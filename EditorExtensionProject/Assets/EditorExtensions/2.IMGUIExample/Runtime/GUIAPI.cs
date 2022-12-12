using System;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {
        private Rect _labelRect = new Rect(10, 90, 100, 20);
        private Rect _buttonRect = new Rect(10, 120, 100, 20);
        private Rect _textFieldRect = new Rect(10, 150, 100, 20);
        private Rect _textAreaRect = new Rect(10, 180, 100, 60);
        private Rect _passwordFieldRect = new Rect(10, 250, 100, 20);
        private Rect _repeatButtonRect = new Rect(10, 280, 100, 20);
        private Rect _toggleRect = new Rect(10, 310, 100, 20);
        private Rect _toolbarRect = new Rect(10, 340, 320, 20);
        private Rect _boxRect = new Rect(10, 370, 100, 60);
        private Rect _horizontalSliderRect = new Rect(10, 440, 100, 20);
        private Rect _verticalSliderRect = new Rect(10, 470, 20, 100);
        private Rect _groupRect = new Rect(10, 580, 200, 200);
        
        
        private string _textFieldValue;
        private string _textAreaValue;
        private string _passwordFieldValue = String.Empty;
        private bool _toggleValue;
        private int _toolbarValue;
        private Vector2 _scrollPosition;
        private float _horizontalSliderValue;
        private float _verticalSliderValue;

        public void Draw()
        {
            _scrollPosition = GUI.BeginScrollView(new Rect(10, 90, 400, 500), _scrollPosition, new Rect(0, 0, 600, 800));
            {
                GUI.Label(_labelRect, "Label");
                if (GUI.Button(_buttonRect, "Button"))
                {
                    Debug.Log("Button Click");
                }

                if (GUI.RepeatButton(_repeatButtonRect, "RepeatButton"))
                {
                    Debug.Log("RepeatButton Click");
                }
            
                _textFieldValue = GUI.TextField(_textFieldRect, _textFieldValue);
                _textAreaValue = GUI.TextArea(_textAreaRect, _textAreaValue);
                _passwordFieldValue = GUI.PasswordField(_passwordFieldRect, _passwordFieldValue, '$');
                _toggleValue = GUI.Toggle(_toggleRect, _toggleValue, "Toggle");
                _toolbarValue = GUI.Toolbar(_toolbarRect, _toolbarValue, new[] {"Toolbar1", "Toolbar2", "Toolbar3"});
                GUI.Box(_boxRect, "Box");
                _horizontalSliderValue = GUI.HorizontalSlider(_horizontalSliderRect, _horizontalSliderValue, 0, 100);
                _verticalSliderValue = GUI.VerticalSlider(_verticalSliderRect, _verticalSliderValue, 0, 100);
                
                GUI.BeginGroup(_groupRect);
                {
                    GUI.Label(new Rect(10, 10, 100, 20), "Group");
                    GUI.Label(new Rect(10, 40, 100, 20), "Group");
                    GUI.Label(new Rect(10, 70, 100, 20), "Group");
                }
                GUI.EndGroup();
            }
            GUI.EndScrollView();
        }
    }
}