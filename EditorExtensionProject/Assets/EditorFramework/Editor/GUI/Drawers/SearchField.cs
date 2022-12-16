using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SearchField : GUIBase
    {
        private int _contentIndex;
        private string _searchContent;
        private string[] _searchableContents;
        private MethodInfo _drawAPI;
        private int _controlID;
        
        public event Action<int> OnModeChanged;
        public event Action<string> OnValueChanged;
        public event Action<string> OnEndEdit; 

        public SearchField(string searchContent, string[] searchableContents, int contentIndex)
        {
            _searchContent = searchContent;
            _searchableContents = searchableContents;
            _contentIndex = contentIndex;

            _drawAPI = typeof(EditorGUI).GetMethod("ToolbarSearchField",
                BindingFlags.NonPublic | BindingFlags.Static,
                null, 
                new[]
                {
                    typeof(int),
                    typeof(Rect),
                    typeof(string[]),
                    typeof(int).MakeByRefType(),
                    typeof(string)
                }, null);
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (_drawAPI != null)
            {
                _controlID = GUIUtility.GetControlID("EditorSearchField".GetHashCode(), FocusType.Keyboard, position);

                int mode = _contentIndex;
                var args = new object[]
                {
                    _controlID,
                    position,
                    _searchableContents,
                    mode,
                    _searchContent
                };
                string newSearchContent = _drawAPI.Invoke(null, args) as string;

                if ((int)args[3] != _contentIndex)
                {
                    _contentIndex = (int)args[3];
                    OnModeChanged?.Invoke(_contentIndex);
                }

                if (newSearchContent != _searchContent)
                {
                    _searchContent = newSearchContent;
                    OnValueChanged?.Invoke(_searchContent);
                }

                var e = Event.current;
                if (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.Escape || e.character == '\n' || e.character == '\t')
                {
                    if (GUIUtility.keyboardControl == _controlID)
                    {
                        GUIUtility.keyboardControl = -1;
                        if (e.type != EventType.Repaint && e.type != EventType.Layout)
                        {
                            e.Use();
                        }
                        OnEndEdit?.Invoke(_searchContent);
                    }
                }
            }
        }
    }
}