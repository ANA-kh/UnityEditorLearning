using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public abstract class XMLGUIBase : GUIBase
    {

        protected T GetAttributeValue<T>(XmlElement xmlElement, string attributeName)
        {
            var attributeValue = xmlElement.GetAttribute(attributeName);

            if (!string.IsNullOrEmpty(attributeValue))
            {
                T result = default;
                if (attributeValue.TryConvert<T>(out result))
                {
                    return result;
                }
            }

            return default;
        }
        
        public virtual void ParseXML(XmlElement xmlElement,XMLGUI rootXMLGUI)
        {
            Id = GetAttributeValue<string>(xmlElement, "id");
            Position = GetAttributeValue<Rect>(xmlElement, "position");
        }
        
        public string Id { get; set; }

        public void SetPosition(Rect position)
        {
            Position = position;
        }
        public void Draw()
        {
            OnGUI(Position);
        }
    }
}