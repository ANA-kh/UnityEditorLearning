using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// Attributes文档 https://docs.unity3d.com/2021.3/Documentation/ScriptReference/AddComponentMenu.html
    /// </summary>
    
    [HelpURL("https://docs.unity3d.com/2021.3/Documentation/ScriptReference/AddComponentMenu.html")]
    public class AttributeExample : MonoBehaviour
    {
        public int Age;

        [HideInInspector]
        public int HideAge;
        
        private int _priAge;
        
        [Header("年龄")]
        [SerializeField]
        private int _SerializeFieldAge;

        [Space(20)]
        public int Space = 20;
        
        [Multiline(5)]
        public string Multiline = "多行文本";
        
        [TextArea(5, 10)]
        public string TextArea = "文本区域";
        
        [Range(0, 100)]
        public int Range = 0;
        
        [My]
        public int My = 0;
    }
}