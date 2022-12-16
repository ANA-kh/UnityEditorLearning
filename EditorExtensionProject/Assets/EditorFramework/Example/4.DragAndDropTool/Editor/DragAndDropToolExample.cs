using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(4)]
    public class DragAndDropToolExample : EditorWindow
    {
        private void OnGUI()
        {
            var rect = new Rect(10, 10, 300, 300);
            GUI.Box(rect, "拖拽一些的东西到这里");

            var info = DragAndDropTool.Drag(Event.current,rect);
            
            if (info.EnterArea && info.Complete && !info.Dragging)
            {
                foreach (var path in info.Paths)
                {
                    Debug.Log(path);
                }

                foreach (var objectReference in info.ObjectReferences)
                {
                    Debug.Log(objectReference);
                }
            }
        }
    }
}
