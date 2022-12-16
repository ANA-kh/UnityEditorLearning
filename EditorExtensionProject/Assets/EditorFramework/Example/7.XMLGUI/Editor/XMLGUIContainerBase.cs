using System;
using System.Collections.Generic;
using System.Xml;

namespace EditorFramework
{
    public abstract class XMLGUIContainerBase : XMLGUIBase
    {
        protected List<XMLGUIBase> Children;

        public override void ParseXML(XmlElement xmlElement ,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);

            Children = rootXMLGUI.ChildElements2GUIBases(xmlElement,rootXMLGUI);
        }

        protected override void OnDispose()
        {
            
        }
    }
}