using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(7)]
    public class XMLGUIExample : EditorWindow
    {
        private const string XMLFilePath = "Assets/EditorFramework/Example/7.XMLGUI/Editor/GUIExample.xml";

        private string _XMLContent;

        private XMLGUI _Xmlgui;
        private void OnEnable()
        {
            
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            _XMLContent = xmlFileAsset.text;

            _Xmlgui = new XMLGUI();
            _Xmlgui.ReadXML(_XMLContent);
            
            
            _Xmlgui.GetGUIBaseById<XMLGUILayoutButton>("loginButton").OnClick += () =>
            {
                Debug.Log("按钮点击了");

                _Xmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label1").Text = "1";
                _Xmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label2").Text = "2";
                _Xmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label3").Text = "3";
                // mXmlgui.GetGUIBaseById<XMLGUITextField>("username").Text = "凉鞋";
                // mXmlgui.GetGUIBaseById<XMLGUITextArea>("description").Text = "本课程的作者，各种作者";
            };
        }

        private void OnGUI()
        {
            _Xmlgui.Draw();
        }
    }
}