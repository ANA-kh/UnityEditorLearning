using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class UndoExample
    {
        private const string PathRoot = "EditorExtensions/07.Undo/";

        [MenuItem(PathRoot + "Create Object")]
        static void CreateObject()
        {
            var go = new GameObject("New Object");
            Undo.RegisterCreatedObjectUndo(go, "Create Object");
        }

        [MenuItem(PathRoot + "Move Object")]
        public static void Move()
        {
            var trans = Selection.activeGameObject.transform;
            if (trans)
            {
                Undo.RecordObject(trans,"MoveObj");
                trans.position += Vector3.up;
            }
        }
        
        [MenuItem(PathRoot + "Add Component")]
        public static void AddComponent()
        {
            var go = Selection.activeGameObject;
            if (go)
            {
                Undo.AddComponent(go,typeof(Rigidbody));
            }
        }
        
        [MenuItem(PathRoot + "Destroy Object")]
        public static void Destroy()
        {
            var go = Selection.activeGameObject;
            if (go)
            {
                Undo.DestroyObjectImmediate(go);
            }
        }
        
        [MenuItem(PathRoot + "SetParent Object")]
        public static void SetParent()
        {
            var trans = Selection.activeGameObject.transform;
            var camera = Camera.main.transform;
            
            if (trans)
            {
                Undo.SetTransformParent(trans,camera,trans.name);
            }
        }
        
        [MenuItem(PathRoot + "Move Object",true)]
        [MenuItem(PathRoot + "Add Component",true)]
        [MenuItem(PathRoot + "Destroy Object",true)]
        [MenuItem(PathRoot + "SetParent Object",true)]
        public static bool Check()
        {
            return Selection.activeGameObject != null;
        }
    }
}