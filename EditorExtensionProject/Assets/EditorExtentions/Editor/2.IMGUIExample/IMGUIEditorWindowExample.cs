using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace EditorExtensions
{
    public class IMGUIEditorWindowExample : EditorWindow
    {
        //IMGUI Immediate Mode GUI(Graphical User Interface)
        [MenuItem("EditorExtensions/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<IMGUIEditorWindowExample>("GUILayoutExample").Show();
        }

        enum APIMode
        {
            GUILayout,
            GUI,
        }
        enum PageID
        {
            GUILayoutAPI,
            GUI_Enable_Color,
            GUIUtility,
            other
        }

        private APIMode _curAPIModeID = APIMode.GUILayout;
        private PageID _curPageID;
        private readonly GUILayoutAPI _guiLayoutAPI = new GUILayoutAPI();
        private readonly GUIAPI _guiAPI = new GUIAPI();

        private void OnGUI()
        {
            _curAPIModeID = (APIMode)GUILayout.Toolbar((int)_curAPIModeID, Enum.GetNames(typeof(APIMode)));
            _curPageID = (PageID)GUILayout.Toolbar((int)_curPageID, Enum.GetNames(typeof(PageID)));
            if (_curPageID == PageID.GUILayoutAPI)
            {
                Basic();
            }

            switch (_curPageID)
            {
                case PageID.GUILayoutAPI:
                    Basic();
                    break;
                case PageID.GUI_Enable_Color:
                    GUI_Enable_Color();
                    break;
                case PageID.GUIUtility:
                    GUIUtilityRotateAndScale();
                    break;
                case PageID.other:
                    break;
            }
        }

        #region Basic

        void Basic()
        {
            if (_curAPIModeID == APIMode.GUI)
            {
                _guiAPI.Draw();
            }
            else
            {
                _guiLayoutAPI.Draw();
            }
        }

        #endregion

        #region RotateAndScale

        private bool _openRotateEffect;
        private bool _openScaleEffect;

        private void GUIUtilityRotateAndScale()
        {
            _openRotateEffect = GUILayout.Toggle(_openRotateEffect, "旋转效果");
            _openScaleEffect = GUILayout.Toggle(_openScaleEffect, "缩放效果");

            if (_openRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45, Vector2.one * 200);
            }

            if (_openScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(Vector2.one * 0.5f, Vector2.one * 200);
            }

            Basic();
        }

        #endregion

        #region EnabledAndColor

        private bool _enableInteractive = true;
        private bool _openColorEffect = false;

        private void GUI_Enable_Color()
        {
            _enableInteractive = GUILayout.Toggle(_enableInteractive, "是否可交互");
            _openColorEffect = GUILayout.Toggle(_openColorEffect, "是否开启颜色效果");

            if (_enableInteractive != GUI.enabled)
            {
                GUI.enabled = _enableInteractive;
            }

            if (_openColorEffect)
            {
                GUI.color = Color.yellow;
            }

            Basic();
        }

        #endregion
    }
}