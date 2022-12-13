using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// https://docs.unity.cn/cn/current/ScriptReference/AssetDatabase.html
    /// </summary>
   public class AssetDatabaseExample : MonoBehaviour
    {
        private const string FolderPath = "Assets/EditorExtensions/5. ProjectExample/02.AssetDatabase";
        private const string FolderName = "NewFolder";
        private const string NewFolderPath = FolderPath + "/" + FolderName;
        private const string NewMaterialPath = NewFolderPath + "/New Materials.mat";

        private const string MENU_PATH = "EditorExtensions/03.Project/01.AssetDatabase";
        
        [MenuItem(MENU_PATH + "/CreateMaterial")]
        static void CreateMaterial()
        {
            if (!Directory.Exists(NewFolderPath))
            {
                string guid = AssetDatabase.CreateFolder(FolderPath, FolderName);
                if (!string.IsNullOrEmpty(AssetDatabase.GUIDToAssetPath(guid)))
                    print("Folder Asset Created !" + guid);
                else
                    print(guid);
            }

            var material = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(material,NewMaterialPath);
            
            if (AssetDatabase.Contains(material))
                print(material.name + " Created");
            else
                print("Failed");
        }

        [MenuItem(MENU_PATH + "/GetMaterialGUID")]
        static void GetGUID()
        {
            Debug.Log(AssetDatabase.AssetPathToGUID(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "/LoadMaterial")]
        static void Load()
        {
            Debug.Log(AssetDatabase.LoadAssetAtPath<Material>(NewMaterialPath));
        }
        
        [MenuItem(MENU_PATH + "/RenameMaterial")]
        static void Rename()
        {
            Debug.Log(AssetDatabase.RenameAsset(NewMaterialPath, "NewName"));
        }
        
        [MenuItem(MENU_PATH + "/MoveMaterial")]
        static void Move()
        {
            Debug.Log(AssetDatabase.MoveAsset(NewMaterialPath, "Assets/move.mat"));
        }

        
        [MenuItem(MENU_PATH + "/CopyMaterial")]
        static void Copy()
        {
            Debug.Log(AssetDatabase.CopyAsset(NewMaterialPath, "Assets/copy.mat"));
        }

        [MenuItem(MENU_PATH + "/DeleteMaterial")]
        static void Delete()
        {
            AssetDatabase.MoveAssetToTrash(NewMaterialPath);
            
            AssetDatabase.DeleteAsset(NewMaterialPath);
            
            AssetDatabase.Refresh();
        }
        
        [MenuItem(MENU_PATH + "/GetMaterialGUID", validate = true)]
        [MenuItem(MENU_PATH + "/LoadMaterial",validate = true)]
        [MenuItem(MENU_PATH + "/RenameMaterial",validate = true)]
        [MenuItem(MENU_PATH + "/MoveMaterial",validate = true)]
        [MenuItem(MENU_PATH + "/CopyMaterial",validate = true)]
        [MenuItem(MENU_PATH + "/DeleteMaterial",validate = true)]
        static bool Check()
        {
            return File.Exists(NewMaterialPath);
        }

        
    }
}