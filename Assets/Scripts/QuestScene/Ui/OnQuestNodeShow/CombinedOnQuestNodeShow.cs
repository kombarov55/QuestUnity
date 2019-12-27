namespace DefaultNamespace.OnQuestNodeShow
{
    public class CombinedOnQuestNodeShow : OnQuestNodeShow
    {
        private OnQuestNodeShow[] callbacks;
        
        public CombinedOnQuestNodeShow(string questNodeId, params OnQuestNodeShow[] callbacks) : base(questNodeId)
        {
            this.callbacks = callbacks;
        }

        public override void run(QuestSceneFlow questSceneFlow)
        {
            foreach (var onQuestNodeShow in callbacks)
            {
                onQuestNodeShow.run(questSceneFlow);
            }
        }
    }
}