using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public SplitType SplitType { get; set; } = SplitType.Vertical;
        public float SplitSize { get; private set; } = 200;
        private float _miniSize;
        private bool _dragging;
        public event Action<Rect> FirstArea, SecondArea;
        public event Action OnBeginResize, OnEndResize;

        public bool Dragging
        {
            get { return _dragging; }
            set
            {
                if (_dragging != value)
                {
                    _dragging = value;
                    if (value)
                    {
                        OnBeginResize?.Invoke();
                    }
                    else
                    {
                        OnEndResize?.Invoke();
                    }
                }
            }
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rect = position.Split(SplitType,SplitSize, 4);
            var mid = position.SplitRect(SplitType,SplitSize, 4);
            //left
            {
                FirstArea?.Invoke(rect[0]);
            }
            //right
            {
                SecondArea?.Invoke(rect[1]);
            }

            EditorGUI.DrawRect(mid.Zoom(new Vector2(-2, -2)), Color.gray);

            var e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                if (SplitType == SplitType.Vertical)
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeHorizontal);
                }
                else
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeVertical);
                }
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (mid.Contains(e.mousePosition))
                    {
                        _dragging = true;
                    }

                    break;
                case EventType.MouseDrag:
                    if (SplitType == SplitType.Vertical)
                    {
                        if (_dragging)
                        {
                            SplitSize += e.delta.x;
                            SplitSize = Mathf.Clamp(SplitSize, _miniSize, position.width - _miniSize);

                            e.Use();
                        }
                    }
                    else
                    {
                        if (_dragging)
                        {
                            SplitSize += e.delta.y;
                            SplitSize = Mathf.Clamp(SplitSize, _miniSize, position.height - _miniSize);

                            e.Use();
                        }
                    }

                    break;
                case EventType.MouseUp:
                    _dragging = false;
                    break;
            }
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            SecondArea = null;
            OnBeginResize = null;
            OnEndResize = null;
        }
    }
}