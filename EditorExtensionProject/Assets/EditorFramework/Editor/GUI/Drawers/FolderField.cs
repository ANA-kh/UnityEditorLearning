using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class FolderField : GUIBase
    {
        public FolderField(string path = "Assets", string folder = "Assets", string title = "Select Folder",
            string defaultName = "")
        {
            _path = path;
            Title = title;
            Folder = folder;
            DefaultName = defaultName;
        }

        protected string _path = "Assets";
        public string Path
        {
            get => _path;
            set => _path = value;
        }
        public string Title;
        public string Folder;
        public string DefaultName;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.Label("Folder Field");
            var rects = position.VerticalSplit(position.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];

            var currentGUIEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(leftRect, _path);
            GUI.enabled = currentGUIEnabled;

            if (GUI.Button(rightRect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel(Title, Folder, DefaultName);
                if (!string.IsNullOrEmpty(path) && path.IsDirectory())
                {
                    _path = path.ToAssetsPath();
                }
            }

            var dragInfo = DragAndDropTool.Drag(Event.current, leftRect);

            if (dragInfo.EnterArea && dragInfo.Complete && !dragInfo.Dragging && dragInfo.Paths[0].IsDirectory())
            {
                _path = dragInfo.Paths[0];
            }
        }

        protected override void OnDispose()
        {
            base.OnDispose();
        }
    }
}