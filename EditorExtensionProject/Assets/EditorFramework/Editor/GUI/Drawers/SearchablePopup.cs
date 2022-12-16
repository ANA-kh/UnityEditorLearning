using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace EditorFramework
{
    public class SearchablePopup : PopupWindowContent
    {
        public static void Show(Rect position, string[] options, int current, Action<int, string> onValueChange, int width = 400)
        {
            SearchablePopup win = new SearchablePopup(options, current, onValueChange,width);
            PopupWindow.Show(position, win);
        }
        private readonly string[] _names;
        private readonly int _width;
        private SearchField _searchField;
        private SelectTree _tree;
        private SearchablePopup(string[] names, int currentIndex, Action<int, string> onSelectionMade,int width=400)
        {
            this._names = names;
            this._width = width;
            _searchField = new SearchField("", null, 0);
            _tree = new SelectTree(new TreeViewState(),this, currentIndex, names, onSelectionMade);
            _searchField.OnValueChanged += (str) =>
            {
                _tree.searchString = str;
            };

        }
        public override Vector2 GetWindowSize()
        {
            return new Vector2(_width, Mathf.Min(600, (_names.Length+1) * EditorStyles.toolbar.fixedHeight+10));
        }
        public override void OnGUI(Rect rect)
        {
            var rs = rect.HorizontalSplit(EditorStyles.toolbar.fixedHeight+5);
            DrawSearch(rs[0].Zoom(AnchorType.LowerCenter,-5));
            _tree.OnGUI(rs[1].Zoom(AnchorType.UpperCenter, -5));
        }

        private void DrawSearch(Rect rect)
        {
            _searchField.OnGUI(rect.Zoom(AnchorType.MiddleCenter, -2));
        }

        private class SelectTree : TreeView
        {
            private static readonly GUIStyle Selection = "SelectionRect";

            private readonly SearchablePopup _pop;
            private readonly int _current;
            private readonly string[] _names;
            private readonly Action<int, string> _onSelectionMade;
            private struct Index
            {
                public int ID;
                public string Value;
            }
            private List<Index> _show;
            public SelectTree(TreeViewState state, SearchablePopup pop,int current,string[] names, Action<int, string> onSelectionMade) : base(state)
            {
                this._pop = pop;
                this._current = current;
                this._names = names;
                this._show = new List<Index>();
                for (int i = 0; i < names.Length; i++)
                {
                    _show.Add(new Index()
                    {
                        ID = names.ToList().IndexOf(names[i]),
                        Value = names[i]
                    });
                }
                this._onSelectionMade = onSelectionMade;
                showAlternatingRowBackgrounds = true;
                Reload();
            }

            protected override TreeViewItem BuildRoot()
            {
                var root = new TreeViewItem { id = 0, depth = -1, displayName = "Root" };
      
                return root;
            }
            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var list = new List<TreeViewItem>();
                for (int i = 0; i < _show.Count; i++)
                {
                    list.Add(new TreeViewItem() { id = _show[i].ID, depth = 1, displayName = _show[i].Value });
                }
                return list;
            }
            protected override void SingleClickedItem(int id)
            {
                base.SingleClickedItem(id);
                _onSelectionMade(id, _names[id]);
                _pop.editorWindow.Close();
                GUIUtility.ExitGUI();
            }
            private void DrawBox(Rect rect, Color tint)
            {
                Color c = GUI.color;
                GUI.color = tint;
                GUI.Box(rect, "", Selection);
                GUI.color = c;
            }
            protected override void SearchChanged(string newSearch)
            {
                _show.Clear();
                for (int i = 0; i < _names.Length; i++)
                {
                    if (_names[i].ToLower().Contains(searchString.ToLower()))
                    {
                        _show.Add(new Index()
                        {
                            ID = _names.ToList().IndexOf(_names[i]),
                            Value = _names[i]
                        });
                    }
                }
                Reload();
            }
           
            protected override void RowGUI(RowGUIArgs args)
            {
                base.RowGUI(args);
                if (args.item.id==_current)
                    DrawBox(args.rowRect, Color.white);
            }
            protected override bool CanMultiSelect(TreeViewItem item)
            {
                return false;
            }
            protected override bool CanBeParent(TreeViewItem item)
            {
                return false;
            }
        }
    }
}
