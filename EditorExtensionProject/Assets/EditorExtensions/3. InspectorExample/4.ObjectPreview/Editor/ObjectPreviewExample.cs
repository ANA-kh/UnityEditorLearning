using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomPreview(typeof(GameObject))]
    public class ObjectPreviewExample : ObjectPreview
    {
        public override bool HasPreviewGUI()
        {
            return true;
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            GUI.Label(r,target.name);
        }
    }
}