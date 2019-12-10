using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace
{
    public class QuestSceneController : MonoBehaviour
    {
        public QuestScenePresenter questScenePresenter;
        public CachedUserData cachedUserData;
        public QuestNodesRepository questNodesRepository;
        public TransitionService transitionService;

        private QuestNode currentQuestNode;

        /**
         * Должен показать текущую сцену в данный момент
         * 1. Найти на какой отановились
         * 2. Показать её
         */
        public void display()
        {
            currentQuestNode = findCurrentQuestNode();
            displayQuestNode(currentQuestNode.imgPath, currentQuestNode.title, currentQuestNode.description, currentQuestNode.choices);
        }

        public void displayQuestNode(string id)
        {
            QuestNode questNode = questNodesRepository.findById(id);
            displayQuestNode(questNode.imgPath, questNode.title, questNode.description, questNode.choices);
            currentQuestNode = questNode;
        }

        public void displayQuestNode(string imgPath, string title, string description, List<QuestNodeChoice> choices)
        {
            questScenePresenter.setImg(imgPath);
            questScenePresenter.setTitle(title);
            questScenePresenter.setDescription(description);
            List<string> choicesStr = new List<string>();
            foreach (var choice in choices)
            {
                choicesStr.Add(choice.text);
            }
            questScenePresenter.setChoices(choicesStr);
        }

        public void handleTransition(int choiceNum)
        {
            transitionService.find(currentQuestNode.id, choiceNum).run(currentQuestNode, choiceNum, this);
        }

        private QuestNode findCurrentQuestNode()
        {
            string currentQuestNodeId = cachedUserData.currentSceneId;
            if (currentQuestNodeId == null || currentQuestNodeId == "")
            {
                currentQuestNodeId = QuestSceneConstants.FIRST_NODE_ID;
            }

            return questNodesRepository.findById(currentQuestNodeId);
        }
    }
}