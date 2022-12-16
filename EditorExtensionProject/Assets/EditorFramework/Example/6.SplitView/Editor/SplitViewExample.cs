using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(6)]
    public class SplitViewExample : EditorWindow
    {
        private SplitView _splitView;

        private void OnEnable()
        {
            _splitView = new SplitView();
            _splitView.SplitType = SplitType.Horizontal;
            _splitView.FirstArea += SplitViewOnFirstArea;
            _splitView.SecondArea += SplitViewOnSecondArea;
        }

        private void SplitViewOnFirstArea(Rect rect)
        {
            rect.DrawOutLine(Color.green);
            GUI.Box(rect, "Left");
        }
        
        private void SplitViewOnSecondArea(Rect rect)
        {
            rect.DrawOutLine(Color.green);
            GUI.Box(rect, "Right");
        }

        private void OnGUI()
        {
            _splitView.OnGUI(this.LocalPosition().Zoom(new Vector2(-10,-10)));
        }
    }
}