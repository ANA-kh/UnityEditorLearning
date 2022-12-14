using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorPrefsExample
    {
        private const string Key = "EditorPrefsExampleTime";
        
        [MenuItem("EditorExtensions/04.Data/EditorPrefs/SaveTime")]
        private static void SaveTime()
        {
            EditorPrefs.SetString(Key, System.DateTime.Now.ToString());
        }
        
        [MenuItem("EditorExtensions/04.Data/EditorPrefs/LoadTime")]
        private static void LoadTime()
        {
            Debug.Log(EditorPrefs.GetString(Key));
        }
    }
}