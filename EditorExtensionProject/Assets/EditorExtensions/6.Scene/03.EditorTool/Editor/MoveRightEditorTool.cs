using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtensions
{
    [EditorTool("Move Right")]//使用"Move Right _i"可添加i为快捷键
    public class MoveRightEditorTool : EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            window.ShowNotification(new GUIContent("Move Right"));

            EditorGUI.BeginChangeCheck();
            Vector3 position = Tools.handlePosition;

            using (new Handles.DrawingScope(Color.green))//在此区域内应用Color.green
            {
                position = Handles.Slider(position, Vector3.right);
                //position = Handles.PositionHandle(position, Quaternion.identity);
            }

            if (EditorGUI.EndChangeCheck())
            {
                Vector3 delta = position - Tools.handlePosition;
                
                Undo.RecordObjects(Selection.transforms,"Move Platforms");//记录可撤销操作

                foreach (var transform in Selection.transforms)
                {
                    transform.position += delta;
                }
            }
        }
    }
}