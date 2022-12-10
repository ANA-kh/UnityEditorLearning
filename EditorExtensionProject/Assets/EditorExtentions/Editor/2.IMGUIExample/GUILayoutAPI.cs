using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// 自动布局的GUI
    /// API演示
    /// 参考：https://docs.unity3d.com/2021.3/Documentation/ScriptReference/GUILayout.html
    /// </summary>
    public class GUILayoutAPI
    {
        private string _textFieldValue;
        private string _textAreaValue;
        private string _passwordValue = string.Empty;
        private Vector2 _scrollPosition;
        private float _sliderValue;
        private Rect _windowRect = new Rect(20, 20, 120, 50);
        private int _toolBarIndex;
        private bool _toggleValue;
        private int _selectionGridIndex;

        public void Draw()
        {
            GUILayout.Label("Hello IMGUI");

            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition); //滚动视图，以GUILayout.EndScrollView();结尾 
            {
                GUILayout.BeginVertical("box");
                {
                    GUILayout.BeginHorizontal(); //水平布局 以GUILayout.EndHorizontal();结尾
                    {
                        GUILayout.Label("TextFiled");
                        //宽高控制
                        _textFieldValue =
                            GUILayout.TextField(_textFieldValue, GUILayout.Width(100), GUILayout.Height(40)); //单行
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(50); //空白

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextArea");
                        //最大最小宽高，拖动窗口大小时有用
                        _textAreaValue = GUILayout.TextArea(_textAreaValue, GUILayout.MinHeight(40),
                            GUILayout.MinWidth(200), GUILayout.MaxHeight(150), GUILayout.MaxWidth(300)); //可回车，多行
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Password");
                        _passwordValue = GUILayout.PasswordField(_passwordValue, '-'); //密码框
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Button");
                        GUILayout.FlexibleSpace(); //自动填充多余区域，可对照下面的按钮查看显示效果
                        if (GUILayout.Button("Button"))
                        {
                            Debug.Log("Click");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("RepeatButton");
                        if (GUILayout.RepeatButton("RepeatButton")) //按下抬起都触发
                        {
                            Debug.Log("RepeatButton");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Box");
                        GUILayout.Box("AutoLayout Box");
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("HorizontalSlider");
                        _sliderValue = GUILayout.HorizontalSlider(_sliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("VerticalSlider");
                        _sliderValue = GUILayout.VerticalSlider(_sliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginArea(new Rect(0, 0, 100, 100)); //忽略自动布局，固定位置大小
                    {
                        GUI.Label(new Rect(0, 0, 20, 20), "Area");
                    }
                    GUILayout.EndArea();

                    //GUILayout.Window(1, _windowRect, (id) => { }, "Window");

                    _toolBarIndex = GUILayout.Toolbar(_toolBarIndex, new[] { "1", "2", "3", "4", "5" });
                    _toggleValue = GUILayout.Toggle(_toggleValue, "Toggle");
                    _selectionGridIndex =
                        GUILayout.SelectionGrid(_selectionGridIndex, new[] { "1", "2", "3", "4", "5" }, 3);
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndScrollView();
        }
    }
}