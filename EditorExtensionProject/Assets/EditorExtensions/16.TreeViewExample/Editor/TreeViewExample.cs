using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace EditorExtensions
{
    public class TreeViewExample : EditorWindow
    {
        [MenuItem("EditorExtensions/12.TreeViewExample/Open")]
        public static void Open()
        {
            GetWindow<TreeViewExample>().Show();
        }

        [SerializeField]
        private TreeViewState _treeViewState;
        private SimpleTreeView _treeView;
        private SearchField _searchField;

        private void OnEnable()
        {
            if (_treeViewState == null)
            {
                _treeViewState = new TreeViewState();
            }

            _treeView = new SimpleTreeView(_treeViewState);
            _treeView.Reload();
            _searchField = new SearchField();
            _searchField.downOrUpArrowKeyPressed += _treeView.SetFocusAndEnsureSelectedItem;
        }

        private void OnGUI()
        {
            using (new GUILayout.HorizontalScope(EditorStyles.toolbar))
            {
                GUILayout.Space(100);
                GUILayout.FlexibleSpace();
                _treeView.searchString = _searchField.OnToolbarGUI(_treeView.searchString);
            }
            var rect = GUILayoutUtility.GetRect(0, 10000,0, 10000);
            _treeView.OnGUI(rect);
        }

        public class SimpleTreeView : TreeView
        {
            public SimpleTreeView(TreeViewState state) : base(state) { }

            public SimpleTreeView(TreeViewState state, MultiColumnHeader multiColumnHeader) : base(state,
                multiColumnHeader) { }

            protected override TreeViewItem BuildRoot()
            {
                var root = new TreeViewItem(0, -1, "Root");
                var allItems = new List<TreeViewItem>()
                {
                    new TreeViewItem(1, 0, "Item 1"),
                    new TreeViewItem(2, 0, "Item 2"),
                    new TreeViewItem(3, 1, "Item 3"),
                    new TreeViewItem(4, 1, "Item 4"),
                    new TreeViewItem(5, 2, "Item 5"),
                    new TreeViewItem(6, 2, "Item 6"),
                    new TreeViewItem(7, 3, "Item 7"),
                    new TreeViewItem(8, 2, "Item 8"),
                };

                SetupParentsAndChildrenFromDepths(root, allItems);
                return root;
            }
        }
    }
}