using UnityEngine;

namespace EditorExtensions
{
    
    /// <summary>
    /// 绘制物体
    /// https://docs.unity.cn/cn/current/ScriptReference/Gizmos.html
    /// </summary>
    public class GizmosExample : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            var color = Gizmos.color;
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
            Gizmos.DrawWireCube(Vector3.one, Vector3.one);
            Gizmos.DrawGUITexture(new Rect(Vector2.zero, Vector2.one * 5f),Texture2D.whiteTexture);
            Gizmos.color = color;
        }

        private void OnDrawGizmosSelected()
        {
            var color = Gizmos.color;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, Vector3.one);
            Gizmos.color = color;
        }
        
        #if UNITY_EDITOR
        [UnityEditor.DrawGizmo(UnityEditor.GizmoType.Active | UnityEditor.GizmoType.Selected)]
        private static void MyCustomOnDrawGizmos(GizmosExample target, UnityEditor.GizmoType gizmoType)
        {
            var color = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawCube(target.transform.position + Vector3.one * 2, Vector3.one);
            Gizmos.color = color;
        }
        #endif
    }
}