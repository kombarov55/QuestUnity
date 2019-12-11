using UnityEngine;

/**
 * Этот класс оркестритует всеми контроллерами. Упраавляет переключением сцен
 */
namespace DefaultNamespace
{
    public class QuestSceneFlow : MonoBehaviour
    {
        public GameObject rootPanel;
        
        public GameObject questScenePanel;

        public GameObject audioGameObject;
        
        public CachedUserData cachedUserData;
        public TransitionService transitionService;
        public QuestNodesRepository questNodesRepository;
        
        private QuestSceneController questSceneController;

        private GameObject instantiatedQuestScenePanel;

        /**
         * При старте показываем обычную сцену
         */
        public void Start()
        {
            instantiatedQuestScenePanel = Instantiate(questScenePanel, rootPanel.transform);
            questSceneController = instantiatedQuestScenePanel.GetComponent<QuestSceneController>();
            questSceneController.init(cachedUserData, questNodesRepository, transitionService, audioGameObject.GetComponent<AudioScript>());
            transitionService.init(questSceneController);
            questSceneController.show();
        }

            public void showQuestScene()
        {
            
        }
    }
}