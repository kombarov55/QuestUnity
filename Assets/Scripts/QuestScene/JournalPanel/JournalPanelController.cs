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

        private List<JournalItem> journalItems;

        public void init(QuestSceneFlow questSceneFlow, AudioScript audioScript)
        {
            Start();
            this.questSceneFlow = questSceneFlow;
            this.audioScript = audioScript;
            journalPanelPresenter.init(audioScript);
        }
        
        
        public void Start()
        {
            journalPanelPresenter = GetComponent<JournalPanelPresenter>();
            journalItemRepository = GetComponent<JournalItemRepository>();
        }

        public void show()
        {
            Start();
            
            gameObject.SetActive(true);
            journalItems = journalItemRepository.getAll();
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