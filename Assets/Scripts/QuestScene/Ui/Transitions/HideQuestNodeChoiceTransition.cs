using DefaultNamespace;
using DefaultNamespace.Common;
using DefaultNamespace.model;
using DefaultNamespace.transitions;

public class HideQuestNodeChoiceTransition : Transition
{

    public HideQuestNodeChoiceTransition(string questNodeId, string choiceText, string nextChoiceId) : base(questNodeId, choiceText, nextChoiceId)
    {
    }

    public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
    {
        var questPanelController = questSceneFlow.questPanelController;
        var observablePrefs = GlobalSerializedState.Get();

        observablePrefs.HiddenQuestNodeIds.Add(nextChoiceId);
        questPanelController.displayQuestNode(selectedChoice.nextId);
        
    }
}
