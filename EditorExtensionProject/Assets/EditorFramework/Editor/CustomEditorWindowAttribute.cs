using System;

namespace EditorFramework
{
    public class CustomEditorWindowAttribute : Attribute
    {
        public int RenderOrder { get; set; }
        
        public CustomEditorWindowAttribute(int renderOrder)
        {
            RenderOrder = renderOrder;
        }
    }
}