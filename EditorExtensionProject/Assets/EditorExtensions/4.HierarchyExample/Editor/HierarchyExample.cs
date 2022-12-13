using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class HierarchyExample
    {
        private static bool _customHierarchyEnabled = false;
        private const string Path = "EditorExtensions/02.IMGUI/03.Enable Custom Hierarchy";

        static HierarchyExample()
        {
            Menu.SetChecked(Path, _customHierarchyEnabled);
        }
        
        [MenuItem(Path)]
        static void EnableCustomHierarchy()
        {
            if (_customHierarchyEnabled)
            {
                _customHierarchyEnabled = false;
                UnRegisterHierarchy();
            }
            else
            {
                _customHierarchyEnabled = true;
                RegisterHierarchy();
            }
            _customHierarchyEnabled = !_customHierarchyEnabled;
            Menu.SetChecked(Path, _customHierarchyEnabled);
            
            EditorApplication.RepaintHierarchyWindow();
        }

        private static void UnRegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyGUI;
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;
        }

        private static void RegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged()
        {
            //Debug.Log("OnHierarchyChanged");
        }

        private static void OnHierarchyGUI(int instanceid, Rect selectionrect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceid) as GameObject;
            if (obj)
            {

                var tagLabelRect = selectionrect;
                tagLabelRect.x += 100;
                GUI.Label(tagLabelRect,obj.tag);

                var layerLabelRect = tagLabelRect;
                layerLabelRect.x += 100;
                GUI.Label(layerLabelRect, LayerMask.LayerToName(obj.layer));
            }
        }
    }
}