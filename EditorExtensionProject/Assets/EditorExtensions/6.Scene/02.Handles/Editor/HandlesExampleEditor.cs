using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditor(typeof(HandlesExample))]
    public class HandlesExampleEditor : Editor
    {
        public HandlesExample Target => target as HandlesExample;

        private void OnSceneGUI()
        {
            var color = Handles.color;
            Handles.color = new Color(1, 0.8f, 0.4f, 1);
            Handles.DrawWireDisc(Target.transform.position, Target.transform.up, Target.Radius);
            Handles.Label(Target.transform.position, Target.Radius.ToString("F1"));
            
            Handles.BeginGUI();
            if (GUILayout.Button("Hello"))
            {
                Debug.Log("Hello");
            }
            Handles.EndGUI();
        }
    }
}