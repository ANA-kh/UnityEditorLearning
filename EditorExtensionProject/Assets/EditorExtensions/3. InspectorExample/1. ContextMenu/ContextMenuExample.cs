using UnityEngine;

namespace EditorExtensions
{
    public class ContextMenuExample : MonoBehaviour
    {
        [ContextMenu("Hello ContextMenu")]//脚本右键菜单
        void HelloContextMenu()
        {
            Debug.Log("Hello ContextMenu");
        }

        [ContextMenuItem("Print Value","HelloContextMenuItem")]//这个字段的右键菜单
        [SerializeField]
        private string contextMenuItemValue;
        
        void HelloContextMenuItem()
        {
            Debug.Log(contextMenuItemValue);
        }

#if UNITY_EDITOR
        private const string FindScriptPath = "CONTEXT/MonoBehaviour/FindScript";
        [UnityEditor.MenuItem(FindScriptPath)]//这样这个MenuItem会出现在MonoBehaviour的Context(右键菜单？)里
        static void FindScript(UnityEditor.MenuCommand command)
        {
            UnityEditor.Selection.activeObject =
                UnityEditor.MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
        }
        
        private const string CameraScriptPath = "CONTEXT/Camera/LogSelf";
        [UnityEditor.MenuItem(CameraScriptPath)]//Camera的右键菜单
        static void LogSelf(UnityEditor.MenuCommand command)
        {
            Debug.Log(command.context);
        }
#endif
    }
}
