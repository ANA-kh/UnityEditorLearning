using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUIButton : XMLGUIBase
    {
        public string Label;

        public override void ParseXML(XmlElement xmlElement ,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);

            Label = xmlElement.InnerText;
        }

        public event Action OnClick;
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            
            if (GUI.Button(position,Label))
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