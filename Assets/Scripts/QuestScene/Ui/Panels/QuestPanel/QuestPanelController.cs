using System.Collections.Generic;
using DefaultNamespace.Common;
using DefaultNamespace.model;
using DefaultNamespace.OnQuestNodeShow;
using QuestScene.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuestPanelController : MonoBehaviour
    {
        
        public TransitionService transitionService;
        public QuestNodesRepository questNodesRepository;
        public OnQuestNodeShowService onQuestNodeShowService;

        private QuestPanelPresenter _questPanelPresenter;
        private GlobalSerializedState _globalSerializedState;
        
        private QuestNode currentQuestNode;
        
        private QuestSceneFlow questSceneFlow;

        public void init(QuestSceneFlow questSceneFlow, TransitionService transitionService,
            OnQuestNodeShowService onQuestNodeShowService, AudioScript audioScript, Image background)
        {
            _globalSerializedState = GlobalSerializedState.Get();
            _questPanelPresenter = GetComponent<QuestPanelPresenter>();
            questNodesRepository = GetComponent<QuestNodesRepository>();
            
            this.transitionService = transitionService;
            this.onQuestNodeShowService = onQuestNodeShowService;
            this.questSceneFlow = questSceneFlow;

            _questPanelPresenter.init(audioScript, background);
            
            _questPanelPresenter.setChoiceHandler(choiceNum => handleTransition(choiceNum));
        }
        
        /**
         * Должен показать текущую сцену в данный момент
         * 1. Найти на какой отановились
         * 2. Показать её
         */
        public void show()
        {
            gameObject.SetActive(true);
            currentQuestNode = findCurrentQuestNode();
            displayQuestNode(currentQuestNode);
        }

        public void hide()
        {
            gameObject.SetActive(false);
        }

        public void displayQuestNode(string id)
        {
            QuestNode questNode = questNodesRepository.findById(id);
            displayQuestNode(questNode);
            _globalSerializedState.CurrentSceneId.Value = id;
        }
        
        public void displayQuestNode(QuestNode questNode)
        {
            displayQuestNode(questNode.imgPath, questNode.title, questNode.description, questNode.choices);
            onQuestNodeShowService.findOnQuestNodeShow(questNode.id).run(questSceneFlow);
            currentQuestNode = questNode;
            _globalSerializedState.CurrentSceneId.Value = currentQuestNode.id;
        }

        private void displayQuestNode(string imgPath, string title, string description, List<QuestNodeChoice> choices)
        {
            _questPanelPresenter.setImg(imgPath);
            _questPanelPresenter.setTitle(title);
            _questPanelPresenter.setDescription(description);

            var visibleChoices = findVisibleChoices(choices);

            _questPanelPresenter.setChoices(visibleChoices);
        }

        public void handleTransition(QuestNodeChoice selectedChoice)
        {
            transitionService.find(currentQuestNode.id, selectedChoice.text, selectedChoice.nextId).run(currentQuestNode, selectedChoice, questSceneFlow);
        }

        private QuestNode findCurrentQuestNode()
        {
            string currentQuestNodeId = _globalSerializedState.CurrentSceneId.Value;
            if (currentQuestNodeId == null || currentQuestNodeId == "")
            {
                currentQuestNodeId = QuestSceneConstants.FIRST_NODE_ID;
            }

            return questNodesRepository.findById(currentQuestNodeId);
        }

        private List<QuestNodeChoice> findVisibleChoices(List<QuestNodeChoice> choices)
        {
            var visibleChoices = new List<QuestNodeChoice>();
            
            foreach (var choice in choices)
            {
                var isChoiceVisible = !_globalSerializedState.HiddenQuestNodeIds.GetCopy().Contains(choice.nextId);

                if (isChoiceVisible)
                {
                    visibleChoices.Add(choice);
                }
            }

            return visibleChoices;
        }
    }
}