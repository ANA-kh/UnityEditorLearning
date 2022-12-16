using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public static class EditorWindowTool
    {
        public static Rect LocalPosition(this EditorWindow self)
        {
            return new Rect(Vector2.zero, self.position.size);
        }
    }
}