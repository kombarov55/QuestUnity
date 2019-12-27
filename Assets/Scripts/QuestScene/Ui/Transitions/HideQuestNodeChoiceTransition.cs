using DefaultNamespace;
using DefaultNamespace.model;
using DefaultNamespace.transitions;

public class HideQuestNodeChoiceTransition : Transition
{
    private string targetQuestNodeId;

    public HideQuestNodeChoiceTransition(string questNodeId, string choiceText, string choiceNextId) : base(questNodeId, choiceText, choiceNextId)
    {
    }

    public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
    {
        var questPanelController = questSceneFlow.questPanelController;

        questSceneFlow.cachedUserData.hiddenQuestNodes.Add(choiceNextId);
        questPanelController.displayQuestNode(selectedChoice.nextId);
        
    }
}
