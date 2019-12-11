namespace DefaultNamespace.OnQuestNodeShow
{
    public class OpenDiaryNoteOnShow : OnQuestNodeShow
    {

        private string noteId;
        
        public OpenDiaryNoteOnShow(string questNodeId, string noteId) : base(questNodeId)
        {
            this.noteId = noteId;
        }

        public override void run(QuestSceneFlow questSceneFlow)
        {
            questSceneFlow.mainPanelController.openJournalItem(noteId);
        }
    }
}