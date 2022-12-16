using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutVertical : XMLGUIContainerBase
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
                GUILayout.BeginVertical("box");
            }
            else
            {
                GUILayout.BeginVertical();
            }
            
            foreach (var child in Children)
            {
                child.OnGUI(position);
            }
            
            GUILayout.EndVertical();
        }

        protected override void OnDispose()
        {
            
        }
    }
}