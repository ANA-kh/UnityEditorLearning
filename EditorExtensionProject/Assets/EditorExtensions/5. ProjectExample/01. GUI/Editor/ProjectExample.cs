using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]//当项目中的脚本被重新编译（也被称为域重载）时，带有这个属性的静态构造函数被调用
    public class ProjectExample
    {

        static ProjectExample()
        {
            Menu.SetChecked(Path, _customProjectEnabled);
        }
        
        private const string Path = "EditorExtensions/02.IMGUI/04.Enable Custom Project";

        private static bool _customProjectEnabled = false;

        [MenuItem(Path)]
        static void Enable()
        {
            if (_customProjectEnabled)
            {
                _customProjectEnabled = false;
                UnRegisterProject();
            }
            else
            {
                _customProjectEnabled = true;
                RegisterProject();
                //ProjectWindowUtil.CreateFolder();
            }

            Menu.SetChecked(Path, _customProjectEnabled);
            
            EditorApplication.RepaintProjectWindow();
        }

        static void RegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI += OnProjectGUI;
            EditorApplication.projectChanged += OnProjectChanged;
        }

        private static void OnProjectChanged()
        {
            Debug.Log("project changed");
        }

        private static void OnProjectGUI(string guid, Rect selectionrect)
        {
            try
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var files = Directory.GetFiles(assetPath);
                var countLabelRect = selectionrect;
                countLabelRect.x += 150;
                GUI.Label(countLabelRect, files.Length.ToString());
            }
            catch (Exception e)
            {
                
            }
        }

        static void UnRegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI -= OnProjectGUI;
            EditorApplication.projectChanged -= OnProjectChanged;

        }
    }
}