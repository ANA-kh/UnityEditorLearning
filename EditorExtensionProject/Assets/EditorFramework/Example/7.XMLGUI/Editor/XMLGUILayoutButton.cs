using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutButton : XMLGUIBase
    {
        public string Label { get; set; }

        public override void ParseXML(XmlElement xmlElement ,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);

            Label =  xmlElement.InnerText;
        }
        public event Action OnClick;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (GUILayout.Button(Label))
            {
                if (OnClick != null)
                {
                    OnClick();
                }
            }
        }
        protected override void OnDispose()
        {
            
        }
    }
}