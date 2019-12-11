using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace.JournalPanel
{
    
    public class JournalPanelController : MonoBehaviour
    {
        private JournalPanelPresenter journalPanelPresenter;
        private JournalItemRepository journalItemRepository;

        public void Start()
        {
            journalPanelPresenter = GetComponent<JournalPanelPresenter>();
            journalItemRepository = GetComponent<JournalItemRepository>();
        }

        public void show()
        {
            Start();
            
            gameObject.SetActive(true);
            List<JournalItem> journalItems = journalItemRepository.getAll();
            journalPanelPresenter.showJournalItems(journalItems);
        }

        public void hide()
        {
            gameObject.SetActive(false);
        }
    }
}