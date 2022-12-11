using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIEditorExample : MonoBehaviour
    {
        private GUILayoutAPI _guiLayoutAPI = new GUILayoutAPI();
        private GUIAPI _guiAPI = new GUIAPI();
        private int _select;

        private void OnGUI()
        {
            _select = GUILayout.Toolbar(_select, new string[] { "GUILayout", "GUI" });
            if (_select == 0)
            {
                _guiLayoutAPI.Draw();
            }
            else
            {
                _guiAPI.Draw();
            }
        }
    }
}