using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIContentAndGUIStyleExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/02.GUIContentAndGUIStyle")]
        static void Open()
        {
            GetWindow<GUIContentAndGUIStyleExample>()
                .Show();
        }
        
        enum Mode
        {
            GUIContent,
            GUIStyle
        }

        private int _toolbarIndex;

        private GUIStyle _boxStyle = "box";//通过重载隐式类型转换实现

        private Lazy<GUIStyle> _fontStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle("label");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            
            return retStyle;
        });
        
        private Lazy<GUIStyle> _buttonStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle(GUI.skin.button);
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            
            return retStyle;
        });

        

        private void OnGUI()
        {
            _toolbarIndex = GUILayout.Toolbar(_toolbarIndex, Enum.GetNames(typeof(Mode)));

            if (_toolbarIndex == (int)Mode.GUIContent)
            {
                GUILayout.Label("把鼠标放在我身上");
                GUILayout.Label(new GUIContent("把鼠标放在我身上"));
                GUILayout.Label(new GUIContent("把鼠标放在我身上","已经放好了 Yeah"));
                GUILayout.Label(new GUIContent("把鼠标放在我身上",Texture2D.whiteTexture));
                GUILayout.Label(new GUIContent("把鼠标放在我身上",Texture2D.whiteTexture,"这个也放好了 Yeah"));
            }
            else
            {
                GUILayout.Label("Style of default");
                GUILayout.Label("Style of box",_boxStyle);
                GUILayout.Label("Style font",_fontStyle.Value);
                if (GUILayout.Button("Button font", _buttonStyle.Value))
                {
                    Debug.Log("Print Button");
                }
            }
        }
    }
}