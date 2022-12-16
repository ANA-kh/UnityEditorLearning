using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILabel :XMLGUIBase
    {
        public string Text;

        public override void ParseXML(XmlElement xmlElement ,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);

            Text = xmlElement.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUI.Label(position,Text);
        }

        protected override void OnDispose()
        {
            
        }
    }
}