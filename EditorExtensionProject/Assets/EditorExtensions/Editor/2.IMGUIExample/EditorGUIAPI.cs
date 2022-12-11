using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    
    /// <summary>
    /// https://docs.unity.cn/cn/current/ScriptReference/EditorGUI.html
    /// https://docs.unity3d.com/2021.3/Documentation/ScriptReference/EditorGUI.html
    /// </summary>
    public class EditorGUIAPI
    {
        private bool _toggleDisabledGroup = false;
        private Rect _flodoutRect = new Rect(0,90,100,20);
        private Rect _labelRect = new Rect(41,90,100,20);
        private Rect _textFieldRect = new Rect(41,110,100,20);
        private Rect _textAreaRect = new Rect(41,140,100,20);
        private Rect _passwordRect = new Rect(41,170,100,20);
        private Rect _dropDownRect = new Rect(41,200,100,20);
        private Rect _linkedButtonRect = new Rect(41,230,100,20);
        private Rect _toggleRect = new Rect(41,260,100,20);
        private Rect _toggleLeftRect = new Rect(41,290,100,20);
        private Rect _helpBoxRect = new Rect(41,320,100,20);
        private Rect _colorFieldRect = new Rect(41,350,100,20);
        private Rect _boundsFieldRect = new Rect(41,380,300,20);
        private Rect _boundsIntFieldRect = new Rect(41,430,300,20);
        private Rect _curveFieldRect = new Rect(41,480,300,20);
        private Rect _delayedDoubleFieldRect = new Rect(41,530,200,20);
        private Rect _doubleFieldRect = new Rect(41,560,200,20);
        private Rect _enumFlagsFieldRect = new Rect(41,590,200,20);
        private Rect _enumPopupRect = new Rect(41,620,200,20);
        private Rect _gradientFieldRect = new Rect(41,650,200,20);

        private bool _flodout = true;
        private string _textFieldString = "TextField";
        private string _textAreaString = "TextArea";
        private string _passwordString = "Password";
        private bool _toggleBool = false;
        // private bool _toggleLeftBool = false;
        // private int _dropDownInt = 0;
        private Color _colorFieldColor = Color.white;
        private Bounds _bounds;
        private BoundsInt _boundsInt;
        private AnimationCurve _curve = new AnimationCurve();
        private double _delayedDouble = 0.0;
        //private double _double = 0.0;
        private EnumFlagsFieldValue _enumFlags;
        private EnumFlagsFieldValue _enumPopup;
        private Gradient _gradient = new Gradient();
        
        private enum EnumFlagsFieldValue
        {
            A = 1,
            B,
            C
        }

        public void Draw()
        {
            _toggleDisabledGroup = EditorGUILayout.Toggle("Disabled Group", _toggleDisabledGroup);

            _flodout = EditorGUI.Foldout(_flodoutRect,_flodout, "折叠");
            EditorGUI.BeginDisabledGroup(_toggleDisabledGroup);
            if (_flodout)
            {
                EditorGUI.LabelField(_labelRect, "Hello World");
                _textFieldString = EditorGUI.TextField(_textFieldRect, _textFieldString);
                _textAreaString = EditorGUI.TextArea(_textAreaRect, _textAreaString);
                _passwordString = EditorGUI.PasswordField(_passwordRect, _passwordString);
                if (EditorGUI.DropdownButton(_dropDownRect, new GUIContent("Dropdown"), FocusType.Keyboard))
                {
                    Debug.Log("DropdownButton clicked");
                    // var window = new IMGUIEditorWindowExample();
                    // window.ShowAsDropDown(_dropDownRect,Vector2.one * 200);
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Item 1"), false, null, "Item 1");
                    menu.AddItem(new GUIContent("Item 2"), false, null, "Item 2");
                    menu.DropDown(_dropDownRect);
                }
                if (EditorGUI.LinkButton(_linkedButtonRect, "Link Button"))
                {
                    Debug.Log("Link Button clicked");
                }
                
                _toggleBool = EditorGUI.Toggle(_toggleRect, _toggleBool);
                _toggleBool = EditorGUI.ToggleLeft(_toggleLeftRect, "Toggle Right", _toggleBool);
                
                EditorGUI.HelpBox(_helpBoxRect, "Help Box", MessageType.Info);
                _colorFieldColor = EditorGUI.ColorField(_colorFieldRect, _colorFieldColor);
                _bounds = EditorGUI.BoundsField(_boundsFieldRect, _bounds);
                _boundsInt = EditorGUI.BoundsIntField(_boundsIntFieldRect, _boundsInt);
                _curve = EditorGUI.CurveField(_curveFieldRect, _curve);
                
                EditorGUI.LabelField(_labelRect, "Hello World");
                _delayedDouble = EditorGUI.DelayedDoubleField(_delayedDoubleFieldRect,new GUIContent("Delayed Double"), _delayedDouble);
                _delayedDouble = EditorGUI.DoubleField(_doubleFieldRect, _delayedDouble);
                _enumFlags = (EnumFlagsFieldValue)EditorGUI.EnumFlagsField(_enumFlagsFieldRect, _enumFlags);
                _enumPopup = (EnumFlagsFieldValue)EditorGUI.EnumPopup(_enumPopupRect, _enumPopup);
                _gradient = EditorGUI.GradientField(_gradientFieldRect, _gradient);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}