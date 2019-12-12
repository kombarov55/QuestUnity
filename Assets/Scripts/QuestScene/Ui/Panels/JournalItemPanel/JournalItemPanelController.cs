using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace.JournalItemPanel
{
    public class JournalItemPanelController : MonoBehaviour
    {
        private JournalItemPanelPresenter journalItemPanelPresenter;
        private QuestSceneFlow questSceneFlow;

        public void init(QuestSceneFlow questSceneFlow, AudioScript audioScript)
        {
            this.questSceneFlow = questSceneFlow;
            journalItemPanelPresenter = GetComponent<JournalItemPanelPresenter>();
            journalItemPanelPresenter.init(audioScript);
        }
        
        public void show(JournalItem journalItem)
        {
            journalItemPanelPresenter.setImage(journalItem.imgPath);
            journalItemPanelPresenter.setTitle(journalItem.title);
            journalItemPanelPresenter.setDescription(journalItem.description);
        }

        public void onBackClicked()
        {
            questSceneFlow.hideJournalItemPanel();
            questSceneFlow.showJournalPanel();
        }
        
    }
}