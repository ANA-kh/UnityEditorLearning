using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        private List<XMLGUIBase> _GUIBases;
        private Dictionary<string, XMLGUIBase> _GUIBaseForId = new Dictionary<string, XMLGUIBase>();
        
        public void Draw()
        {
            foreach (var xmlguiBase in _GUIBases)
            {
                xmlguiBase.Draw();
            }
        }

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;
            if (_GUIBaseForId.TryGetValue(id, out t))
            {
                return t as T;
            }
            else
            {
                return default;
            }
        }

        private Dictionary<string, Func<XMLGUIBase>> FactoriesForGUIBaseNames =
            new Dictionary<string, Func<XMLGUIBase>>()
            {
                { "Label", () => new XMLGUILabel() },
                { "TextField", () => new XMLGUITextField() },
                { "TextArea", () => new XMLGUITextArea() },
                { "Button", () => new XMLGUIButton() },
                { "LayoutLabel", () => new XMLGUILayoutLabel() },
                { "LayoutButton", () => new XMLGUILayoutButton() },
                { "LayoutHorizontal", () => new XMLGUILayoutHorizontal() },
                { "LayoutVertical", () => new XMLGUILayoutVertical() }
            };

        public void ReadXML(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");
            _GUIBases = ChildElements2GUIBases(rootNode as XmlElement, this);
        }

        public List<XMLGUIBase> ChildElements2GUIBases(XmlElement rootElement, XMLGUI xmlgui)
        {
            var result = new List<XMLGUIBase>();
            Func<XMLGUIBase> xmlGUIBaseFactory = default;
            XMLGUIBase xmlGUIBase = default;

            foreach (XmlElement rootNodeChildNode in rootElement.ChildNodes)
            {
                if (FactoriesForGUIBaseNames.TryGetValue(rootNodeChildNode.Name, out xmlGUIBaseFactory))
                {
                    xmlGUIBase = xmlGUIBaseFactory();
                    xmlGUIBase.ParseXML(rootNodeChildNode, xmlgui);
                    xmlgui.RegisterGUIBaseForId(xmlGUIBase);
                    result.Add(xmlGUIBase);
                }
            }
            return result;
        }

        void RegisterGUIBaseForId(XMLGUIBase guiBase)
        {
            if (!string.IsNullOrEmpty(guiBase.Id))
            {
                _GUIBaseForId.Add(guiBase.Id, guiBase);
            }
        }
    }
}