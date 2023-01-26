using System;
using System.Collections.Generic;

namespace MiniDialogue
{
    public enum DialogueState
    {
        NotStart,
        Started,
    }

    public class DialogueController : IDialogueController
    {
        public DialogueState State { get; private set; } = DialogueState.NotStart;

        public int CurrentNodeIndex { get; private set; } = 0;
        
        // 全局默认的对话控制器
        public static readonly DialogueController Default = new DialogueController();

        public event Action<string, List<DialogueEventArg>> OnCustomEvent = (s, list) => { };

        public Func<string, string> Translator = text => text;

        /// <summary>
        /// 与 View 进行关联
        /// </summary>
        /// <param name="view"></param>
        public void ConnectView(IDialogueView view)
        {
            View = view;
            View.Controller = this;
        }
        public void SetData(DialogueData dialogueData)
        {
            mDialogueData = dialogueData;
        }
        
        public void TriggerCustomEvent(string eventName, List<DialogueEventArg> args)
        {
            OnCustomEvent?.Invoke(eventName, args);
        }

        public string Translate(string text)
        {
            return Translator(text);
        }

        public void DisconnectView(IDialogueView view)
        {
            View.Controller = null;
            View = null;
        }

        public void MoveToNext()
        {
            CurrentNodeIndex++;
        }

        public void NextStep()
        {
            CurrentNodeIndex++;
            Step();
        }

        public void StepAtFirst()
        {
            CurrentNodeIndex = 0;
            Step();
        }

        public bool StepEnable { get; set; } = true;

        public IDialogueView View { get; private set; }

        public void Init()
        {
            State = DialogueState.NotStart;
            CurrentNodeIndex = 0;
            View?.OnViewInit();
        }

        public void Step()
        {
            if (!StepEnable) return;
            if (State == DialogueState.NotStart)
            {
                State = DialogueState.Started;
                CurrentNodeIndex = 0;
                View.OnDialogueStart();
            }

            if (State == DialogueState.Started)
            {
                if (mDialogueData.Nodes.Count <= CurrentNodeIndex)
                {
                    State = DialogueState.NotStart;
                    View?.OnDialogueFinish();
                }
                else
                {
                    // 播放对话
                    var node = mDialogueData.Nodes[CurrentNodeIndex];
                    View?.OnDialogueNodeStart(node);
                }
            }
        }

        private DialogueData mDialogueData;
    }
}