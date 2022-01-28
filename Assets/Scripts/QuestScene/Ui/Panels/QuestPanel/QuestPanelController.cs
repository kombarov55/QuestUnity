using System.Collections.Generic;
using DefaultNamespace.model;
using DefaultNamespace.OnQuestNodeShow;
using QuestScene.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuestPanelController : MonoBehaviour
    {
        
        public CachedPrefs cachedPrefs;
        public TransitionService transitionService;
        public QuestNodesRepository questNodesRepository;
        public OnQuestNodeShowService onQuestNodeShowService;

        private QuestPanelPresenter _questPanelPresenter;
        
        private QuestNode currentQuestNode;
        
        private QuestSceneFlow questSceneFlow;

        public void init(QuestSceneFlow questSceneFlow, CachedPrefs cachedPrefs, TransitionService transitionService, OnQuestNodeShowService onQuestNodeShowService, AudioScript audioScript, Image background)
        {
            _questPanelPresenter = GetComponent<QuestPanelPresenter>();
            questNodesRepository = GetComponent<QuestNodesRepository>();
            
            this.cachedPrefs = cachedPrefs;
            this.transitionService = transitionService;
            this.onQuestNodeShowService = onQuestNodeShowService;
            this.questSceneFlow = questSceneFlow;

            cachedPrefs.Load();

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
            Prefs.CurrentSceneId = id;
        }
        
        public void displayQuestNode(QuestNode questNode)
        {
            displayQuestNode(questNode.imgPath, questNode.title, questNode.description, questNode.choices);
            onQuestNodeShowService.findOnQuestNodeShow(questNode.id).run(questSceneFlow);
            currentQuestNode = questNode;
            Prefs.CurrentSceneId = currentQuestNode.id;
        }

        private void displayQuestNode(string imgPath, string title, string description, List<QuestNodeChoice> choices)
        {
            _questPanelPresenter.setImg(imgPath);
            _questPanelPresenter.setTitle(title);
            _questPanelPresenter.setDescription(description);

            var visibleChoices = findVisibleChoices(cachedPrefs, choices);

            _questPanelPresenter.setChoices(visibleChoices);
        }

        public void handleTransition(QuestNodeChoice selectedChoice)
        {
            transitionService.find(currentQuestNode.id, selectedChoice.text, selectedChoice.nextId).run(currentQuestNode, selectedChoice, questSceneFlow);
        }

        private QuestNode findCurrentQuestNode()
        {
            string currentQuestNodeId = Prefs.CurrentSceneId;
            if (currentQuestNodeId == null || currentQuestNodeId == "")
            {
                currentQuestNodeId = QuestSceneConstants.FIRST_NODE_ID;
            }

            return questNodesRepository.findById(currentQuestNodeId);
        }

        private List<QuestNodeChoice> findVisibleChoices(CachedPrefs cachedPrefs, List<QuestNodeChoice> choices)
        {
            var visibleChoices = new List<QuestNodeChoice>();
            
            foreach (var choice in choices)
            {
                var isChoiceVisible = !cachedPrefs.HiddenQuestNodes.Contains(choice.nextId);

                if (isChoiceVisible)
                {
                    visibleChoices.Add(choice);
                }
            }

            return visibleChoices;
        }
    }
}