using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// 编辑器事件 Attribute
    /// </summary>
    [InitializeOnLoad]//编译完成和运行时调用类的静态构造函数
    public class EditorEventAttributeExample
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("EditorEventAttributeExample");
        }
        
        [InitializeOnLoadMethod] //这个属于在Editor命名空间，打包后没有；游戏内版本[RuntimeInitializeOnLoadMethod]
        private static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }
        
        [DidReloadScripts]
        private static void DidReloadScripts()
        {
            Debug.Log("DidReloadScripts");
        }
        
        [PostProcessScene]
        private static void PostProcessScene()
        {
            Debug.Log("PostProcessScene");
        }

        [PostProcessBuild]
        private static void PostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            Debug.Log("PostProcessBuild");
        }
        
        [OnOpenAsset(1)]
        private static bool OnOpenAsset(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log($"OnOpenAsset 1 {name}");
            return false;
        }
        [OnOpenAsset(2)]
        private static bool OnOpenAsset2(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log($"OnOpenAsset 2 {name}");
            return false;
        }
    }
}