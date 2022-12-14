using UnityEngine;

namespace EditorExtensions
{
    public class GUIWindowExample : MonoBehaviour
    {
        public Rect windowRect = new Rect(20, 20, 120, 50);

        void OnGUI()
        {
            // Register the window. Notice the 3rd parameter
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");//在Game视图显示
        }

        // Make the contents of the window
        void DoMyWindow(int windowID)
        {
            if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            {
                print("Got a click");
            }
        }
    }
}