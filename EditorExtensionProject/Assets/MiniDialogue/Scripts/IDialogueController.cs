using System.Collections.Generic;

namespace MiniDialogue
{
    public interface IDialogueController
    {
        bool StepEnable { get; set; }
        
        IDialogueView View { get;}
        void Init();
        void Step();
        void NextStep();
        void StepAtFirst();
        void MoveToNext();
        void TriggerCustomEvent(string eventName, List<DialogueEventArg> args);

        string Translate(string text);
    }
}