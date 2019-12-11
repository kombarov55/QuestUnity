namespace DefaultNamespace.OnQuestNodeShow
{
    public abstract class OnQuestNodeShow
    {
        public string questNodeId;

        protected OnQuestNodeShow(string questNodeId)
        {
            this.questNodeId = questNodeId;
        }

        public abstract void run(QuestSceneFlow questSceneFlow);
    }
}