using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutHorizontal : XMLGUIContainerBase
    {
        public bool Box { get; set; }
        
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);
            Box = GetAttributeValue<bool>( xmlElement,"box");
        }
        
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (Box)
            {
                GUILayout.BeginHorizontal("box");
            }
            else
            {
                GUILayout.BeginHorizontal();
            }
            
            foreach (var child in Children)
            {
                child.OnGUI(position);
            }

            GUILayout.EndHorizontal();
        }

        protected override void OnDispose()
        {
        }
    }
}