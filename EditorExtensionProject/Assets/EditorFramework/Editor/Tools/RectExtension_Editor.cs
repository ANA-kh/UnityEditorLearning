using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public static class RectExtension_Editor
    {
        public static void DrawOutLine(this Rect self, Color color)
        {
            Handles.color = color;
            Handles.DrawAAPolyLine(2,
                new Vector2(self.x,self.y),
                new Vector2(self.x ,self.yMax),
                new Vector2(self.xMax,self.yMax),
                new Vector2(self.xMax,self.y),
                new Vector2(self.x,self.y));
            
            Handles.color = Color.white;
        }
    }
}