using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    /// <summary>
    /// 拖拽工具类
    /// </summary>
    public static class DragAndDropTool 
    {
        public class DragInfo
        {
            public bool Dragging;
            public bool EnterArea;
            public bool Complete;
            public Object[] ObjectReferences => DragAndDrop.objectReferences;
            public string[] Paths => DragAndDrop.paths;
            public DragAndDropVisualMode VisualMode => DragAndDrop.visualMode;
            public int ActiveControlID => DragAndDrop.activeControlID;
        }

        private static DragInfo _dragInfo = new DragInfo();

        private static bool _dragging;
        private static bool _enterArea;
        private static bool _complete;
        
        /// <summary>
        /// 使传入的区域相应拖拽事件，返回拖拽结果信息
        /// </summary>
        /// <param name="e"></param>
        /// <param name="rect"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static DragInfo Drag(Event e,Rect rect,DragAndDropVisualMode mode = DragAndDropVisualMode.Generic)
        {
            if (e.type == EventType.DragUpdated)
            {
                _complete = false;
                _dragging = true;
                _enterArea = rect.Contains(e.mousePosition);
                if (_enterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                _complete = true;
                _dragging = false;
                _enterArea = rect.Contains(e.mousePosition);
                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                _complete = true;
                _dragging = false;
                _enterArea = rect.Contains(e.mousePosition);
            }
            else
            {
                _complete = false;
                _dragging = false;
                _enterArea = rect.Contains(e.mousePosition);
            }

            _dragInfo.Complete = _complete && e.type == EventType.Used;
            _dragInfo.EnterArea = _enterArea;
            _dragInfo.Dragging = _dragging;

            return _dragInfo;
        }
    }
}