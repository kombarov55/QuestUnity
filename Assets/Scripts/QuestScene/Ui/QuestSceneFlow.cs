using DefaultNamespace.AnimationPanel;
using DefaultNamespace.JournalItemPanel;
using DefaultNamespace.JournalPanel;
using DefaultNamespace.MainPanel;
using DefaultNamespace.model;
using DefaultNamespace.OnQuestNodeShow;
using DefaultNamespace.Panels.InventoryPanel;
using QuestScene.Repositories;
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

        public GameObject questPanelPrefab;
        public GameObject journalPanelPrefab;
        public GameObject journalItemPanelPrefab;
        public GameObject animationPanelPrefab;
        public GameObject inventoryPanelPrefab;

        public GameObject audioGameObject;

        public CachedUserData cachedUserData;
        public TransitionService transitionService;
        public OnQuestNodeShowService onQuestNodeShowService;
        public AudioScript audioScript;
        public JournalItemsService journalItemsService;

        public QuestPanelController questPanelController;
        public JournalPanelController journalPanelController;
        public JournalItemPanelController journalItemPanelController;
        public MainPanelController mainPanelController;
        public AnimationPanelController animationPanelController;
        public InventoryPanelController InventoryPanelController;

        private GameObject questPanel;
        private GameObject journalPanel;
        private GameObject journalItemPanel;
        private GameObject animationPanel;
        private GameObject mainPanel;
        private GameObject inventoryPanel;

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
            mainPanel = rootPanel.transform.Find("MainPanel").gameObject;
            audioScript = audioGameObject.GetComponent<AudioScript>();

            questPanel = Instantiate(questPanelPrefab, mainPanel.transform);
            questPanel.SetActive(false);
            journalPanel = Instantiate(journalPanelPrefab, rootPanel.transform);
            journalPanel.SetActive(false);
            animationPanel = Instantiate(animationPanelPrefab, rootPanel.transform);
            animationPanel.SetActive(false);
            journalItemPanel = Instantiate(journalItemPanelPrefab, rootPanel.transform);
            journalItemPanel.SetActive(false);
            inventoryPanel = Instantiate(inventoryPanelPrefab, rootPanel.transform);
            inventoryPanel.SetActive(false);
            
            transitionService = GetComponent<TransitionService>();
            transitionService.init();
            
            journalItemsService = GetComponent<JournalItemsService>();
            journalItemsService.init();

            onQuestNodeShowService = GetComponent<OnQuestNodeShowService>();

            questPanelController = questPanel.GetComponent<QuestPanelController>();
            questPanelController.init(this, cachedUserData, transitionService, onQuestNodeShowService, audioScript, rootPanel.GetComponent<Image>());

            journalPanelController = journalPanel.GetComponent<JournalPanelController>();
            journalPanelController.init(this, audioScript, journalItemsService);

            journalItemPanelController = journalItemPanel.GetComponent<JournalItemPanelController>();
            journalItemPanelController.init(this, audioScript);

            mainPanelController = mainPanel.GetComponent<MainPanelController>();
            mainPanelController.init(cachedUserData, journalItemsService);
            
            animationPanelController = animationPanel.GetComponent<AnimationPanelController>();
            animationPanelController.init();

            InventoryPanelController = inventoryPanel.GetComponent<InventoryPanelController>();
            InventoryPanelController.init(audioScript, this);
        }

        public void showQuestScene()
        {
            mainPanel.SetActive(true);
            questPanel.SetActive(true);
            questPanelController.show();
        }

        public void showMainPanel()
        {
            mainPanel.SetActive(true);
        }
        
        public void hideMainPanel()
        {
            mainPanel.SetActive(false);
        }

        public void showJournalPanel()
        {
            mainPanelController.dropUnreadJournalItemsCounter();
            journalPanelController.show();
        }
        
        public void hideJournalPanel()
        {
            journalPanelController.hide();
        }

        public void showJournalItemPanel(JournalItem journalItem)
        {
            journalItemPanel.SetActive(true);
            journalItemPanelController.show(journalItem);
        }

        public void hideJournalItemPanel()
        {
            journalItemPanel.SetActive(false);
        }

        public void showInventoryPanel()
        {
            inventoryPanel.SetActive(true);
            mainPanelController.dropUnseenInventoryItemsCount();
            InventoryPanelController.show(InventoryItemsRepository.findOpened(cachedUserData.addedInventoryItems));
        }

        public void hideInventoryPanel()
        {
            inventoryPanel.SetActive(false);
        }

    }
}