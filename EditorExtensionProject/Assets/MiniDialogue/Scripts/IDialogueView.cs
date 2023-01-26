namespace MiniDialogue
{
    public interface IDialogueView
    {
        IDialogueController Controller { get; set; }
        void OnViewInit();
        void OnDialogueStart();
        void OnDialogueNodeStart(DialogueNode node);

        void OnDialogueFinish();
    }
}