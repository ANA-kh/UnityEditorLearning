using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// 监听资源操作
    /// </summary>
    public class AssetModificationProcessorExample : AssetModificationProcessor
    {
        private static void OnWillCreateAsset(string assetName)
        {
            Debug.Log("OnWillCreateAsset: " + assetName);
        }

        private static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            Debug.Log("OnWillDeleteAsset: " + assetPath);

            if (EditorUtility.DisplayDialog("Delete Asset", "Are you sure you want to delete " + assetPath + "?", "Yes", "No"))
            {
                return AssetDeleteResult.DidNotDelete;
            }
            
            {
                return AssetDeleteResult.FailedDelete;
            }
        }

        private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            Debug.Log("OnWillMoveAsset: " + sourcePath + " to " + destinationPath);

            if (EditorUtility.DisplayDialog("Move Asset", "Are you sure you want to move " + sourcePath + " to " + destinationPath + "?", "Yes", "No"))
            {
                //AssetMoveResult.DidMove 告诉unity已经移动了，不用unity自己在移动
                return AssetMoveResult.DidNotMove;
            }
            
            {
                return AssetMoveResult.FailedMove;
            }
        }

        private static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log("OnWillSaveAssets: " + paths.Length);
            return paths;
        }

        private static bool CanOpenForEdit(string[] paths, List<string> outNotEditablePaths, StatusQueryOptions statusQueryOptions)
        {
            Debug.Log("CanOpenForEdit: " + paths.Length);
            return true;
        }

        private static void FileModeChanged(string[] paths, FileMode mode)
        {
            Debug.Log($"FileModeChanged:{mode}");

            foreach (var path in paths)
            {
                Debug.Log(path);
            }
        }

        private static bool MakeEditable(string[] paths, string prompt, List<string> outNotEditablePaths)
        {
            Debug.Log($"MakeEditable: {prompt}");
            
            foreach (var path in paths)
            {
                Debug.Log(path);
            }
            return true;
        }
    }
}