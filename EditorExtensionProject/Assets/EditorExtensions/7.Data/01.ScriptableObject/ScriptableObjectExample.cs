using UnityEngine;

namespace EditorExtensions
{
    [CreateAssetMenu(fileName = "New ScriptableObjectExample", menuName = "Scriptable Objects/Scriptable Object")]
    public class ScriptableObjectExample : ScriptableObject
    {
        public int myInt;
        public string myString;
    }
}