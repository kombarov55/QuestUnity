using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace.JournalPanel
{
    public class JournalPanelController : MonoBehaviour
    {
        private JournalPanelPresenter journalPanelPresenter;
        private JournalItemRepository journalItemRepository;

        private QuestSceneFlow questSceneFlow;
        private AudioScript audioScript;
        private JournalItemsService journalItemsService;

        private List<JournalItem> journalItems;

        public void init(QuestSceneFlow questSceneFlow, AudioScript audioScript, JournalItemsService journalItemsService)
        {
            Start();
            this.questSceneFlow = questSceneFlow;
            this.audioScript = audioScript;
            this.journalItemsService = journalItemsService;
            journalPanelPresenter.init(audioScript);
        }


        public void Start()
        {
            journalPanelPresenter = GetComponent<JournalPanelPresenter>();
            journalItemRepository = GetComponent<JournalItemRepository>();
        }

        public void show()
        {
            gameObject.SetActive(true);
            journalItems = journalItemsService.GetOpenedJournalItems(journalItemRepository);
            journalPanelPresenter.setOnItemSelectedCallback(i => toJournalItemPanel(i));
            journalPanelPresenter.showJournalItems(journalItems);
        }

        public void hide()
        {
            gameObject.SetActive(false);
        }

        public void playOnClickSound()
        {
            audioScript.playButtonClickSound();
        }

        public void onBackClicked()
        {
            journalPanelPresenter.clear();
            questSceneFlow.hideJournalPanel();
            questSceneFlow.showMainPanel();
        }

        public void toJournalItemPanel(int selectedIndex)
        {
            JournalItem selectedItem = journalItems[selectedIndex];
            journalPanelPresenter.clear();
            questSceneFlow.hideJournalPanel();
            questSceneFlow.showJournalItemPanel(selectedItem);
        }
    }
}