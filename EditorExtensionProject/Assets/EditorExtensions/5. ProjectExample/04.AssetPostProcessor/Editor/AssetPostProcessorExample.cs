using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// 监听资源导入
    /// </summary>
    public class AssetPostProcessorExample : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            Debug.Log("OnPreprocessTexture" + this.assetPath);
            var importer = this.assetImporter as TextureImporter;
            if (importer != null)
            {
                importer.textureType = TextureImporterType.Sprite;
                importer.maxTextureSize = 512;
                importer.mipmapEnabled = false;
            }
        }
        
        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("OnPostprocessTexture" + this.assetPath);
        }
    }
}