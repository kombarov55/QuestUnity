using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.JournalPanel
{
    
    public class JournalPanelPresenter : MonoBehaviour
    {
        public GameObject journalItemPrefab;
        public GameObject journalItemContainer;

        private List<GameObject> instantiatedJournalItems = new List<GameObject>();

        public void showJournalItems(List<JournalItem> journalItems)
        {
            foreach (JournalItem journalItem in journalItems)
            {
                GameObject gameObject = Instantiate(journalItemPrefab, journalItemContainer.transform);
                Text titleText = gameObject.transform.Find("Title").GetComponent<Text>();
                Text descriptionText = gameObject.transform.Find("Description").GetComponent<Text>();
                Image image = gameObject.transform.Find("Image").GetComponent<Image>();

                titleText.text = journalItem.title;
                descriptionText.text = journalItem.description;
                if (journalItem.imgPath != null && journalItem.imgPath != "")
                {
                    Sprite imageSprite = Resources.Load<Sprite>(journalItem.imgPath);
                    image.sprite = imageSprite;
                }

                instantiatedJournalItems.Add(gameObject);
            }
        }

    }
}