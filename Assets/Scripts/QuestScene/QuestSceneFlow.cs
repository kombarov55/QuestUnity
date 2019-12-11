using DefaultNamespace.JournalPanel;
using DefaultNamespace.MainPanel;
using UnityEngine;
using UnityEngine.UI;

/**
 * Этот класс оркестритует всеми контроллерами. Упраавляет переключением сцен
 */
namespace DefaultNamespace
{
    public class QuestSceneFlow : MonoBehaviour
    {
        public GameObject rootPanel;

        public GameObject questScenePanel;
        public GameObject journalPanel;

        public GameObject audioGameObject;

        public CachedUserData cachedUserData;
        public TransitionService transitionService;

        public QuestPanelController questPanelController;
        public JournalPanelController journalPanelController;
        public MainPanelController mainPanelController;
        

        private GameObject instantiatedQuestScenePanel;
        private GameObject instantiatedJournalPanel;

        /**
         * При старте показываем обычную сцену
         */
        public void Start()
        {
            init();
//            showJournalPanel();
            showQuestScene();
        }

        private void init()
        {
            instantiatedQuestScenePanel = Instantiate(questScenePanel, rootPanel.transform);
            instantiatedQuestScenePanel.SetActive(false);
            instantiatedJournalPanel = Instantiate(journalPanel, rootPanel.transform);
            instantiatedJournalPanel.SetActive(false);

            questPanelController = instantiatedQuestScenePanel.GetComponent<QuestPanelController>();
            questPanelController.init(this, cachedUserData, transitionService, audioGameObject.GetComponent<AudioScript>(), rootPanel.GetComponent<Image>());

            transitionService = GetComponent<TransitionService>();
            transitionService.init(questPanelController);

            journalPanelController = instantiatedJournalPanel.GetComponent<JournalPanelController>();

            mainPanelController = rootPanel.transform.Find("MainPanel").GetComponent<MainPanelController>();
            mainPanelController.init(cachedUserData);
        }

        public void showQuestScene()
        {
            questPanelController.show();
        }

        public void showJournalPanel()
        {
            journalPanelController.show();
        }
        
        
    }
}