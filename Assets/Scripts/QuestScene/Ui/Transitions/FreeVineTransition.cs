using DefaultNamespace.AnimationPanel;
using DefaultNamespace.MainPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class FreeVineTransition : Transition
    {
        public FreeVineTransition(string questNodeId, string choiceText, string nextChoiceId) : base(questNodeId, choiceText, nextChoiceId)
        {
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice,
            QuestSceneFlow questSceneFlow)
        {
            QuestPanelController questPanelController = questSceneFlow.questPanelController;
            AnimationPanelController animationPanelController = questSceneFlow.animationPanelController;
            MainPanelController mainPanelController = questSceneFlow.mainPanelController;

            
            /*
                 1. Показать скример
                 2. Уменьшить количество монет
                 3. Найти сцену после скримера. 
                 4. Изменить в ней id следующего на successId
                 5. Отобразить эту сцену
            */
            animationPanelController.show("Images/Screamer", 
                audioScript => audioScript.playScreamSound(),
                () =>
            {
                QuestNode questNode = questPanelController.questNodesRepository.findById("3.0");
                questNode.choices[0].nextId = "3.4";
                questPanelController.displayQuestNode(questNode);
                mainPanelController.openJournalItem("Красные глаза");
            });
        }
    }
}