using System;
using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace EditorExtensions
{
    
    public class MenuItemExample
    {
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }
        
        [MenuItem("EditorExtensions/01.Menu/02.Open Bilibili")]
        static void OpenBilibili()
        {
            //Application.OpenURL("weixin://");
            //Application.OpenURL("cmd.exe");
            //打开目录、文件、网址、程序等
            Application.OpenURL("https://www.bilibili.com/");
            //Process.Start("C:\\Program Files\\MyProgram.exe");
        }
        
        [MenuItem("EditorExtensions/01.Menu/03.Open PersistantDataPath")]
        static void OpenPersistantDataPath()
        {
            //Application.OpenURL(Application.persistentDataPath);
            //打开目录
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
        
        [MenuItem("EditorExtensions/01.Menu/04.打开策划目录")]
        static void OpenDesignerPath()
        {
            //Application.OpenURL(Application.dataPath.Replace("Assets","Library"));
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets","Library"));
        }
         

        private static bool _OpenShotCut = false;
        [MenuItem("EditorExtensions/01.Menu/05.快捷键开关")]
        static void ToggleShotCut()
        {
            _OpenShotCut = !_OpenShotCut;
            //Toggle 勾选
            Menu.SetChecked("EditorExtensions/01.Menu/05.快捷键开关", _OpenShotCut);
        }
        
        [MenuItem("EditorExtensions/01.Menu/05.Hello Editor _c")]
        static void HelloEditorWithShotCut()
        {
            //菜单按钮调用
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/01.Hello Editor");
        }
        
        [MenuItem("EditorExtensions/01.Menu/06.Open Bilibili %#_t")]
        static void OpenBilibiliWithShotCut()
        {
            Process.Start("https://www.bilibili.com/");
        }
        
        [MenuItem("EditorExtensions/01.Menu/05.Hello Editor _c", validate = true)]
        static bool ValidateHelloEditorWithShotCut()
        {
            return _OpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/06.Open Bilibili %#_t", validate = true)]
        static bool ValidateOpenBilibiliWithShotCut()
        {
            return _OpenShotCut;
        }
        
        //非静态构造函数在创建实例时调用；静态构造函数在创建第一个实例或引用任何静态成员之前自动调用
        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtensions/01.Menu/05.快捷键开关", _OpenShotCut);
        }
    }
}