using System;
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

        private AudioScript audioScript; 

        private Action<int> onItemSelectedCallback;

        private List<GameObject> instantiatedJournalItems = new List<GameObject>();

        public void init(AudioScript audioScript)
        {
            this.audioScript = audioScript;
        }
        
        public void setOnItemSelectedCallback(Action<int> callback)
        {
            onItemSelectedCallback = callback;
        }
        
        public void showJournalItems(List<JournalItem> journalItems)
        {
            for (var i = 0; i < journalItems.Count; i++)
            {
                JournalItem journalItem = journalItems[i];

                GameObject gameObject = Instantiate(journalItemPrefab, journalItemContainer.transform);
                Text titleText = gameObject.transform.Find("Horizontal").Find("InnerVertical").Find("Title")
                    .GetComponent<Text>();
                Text descriptionText = gameObject.transform.Find("Horizontal").Find("InnerVertical").Find("Description")
                    .GetComponent<Text>();
                Image image = gameObject.transform.Find("Horizontal").Find("Image").GetComponent<Image>();

                titleText.text = journalItem.title;
                descriptionText.text = journalItem.description;
                if (journalItem.imgPath != null && journalItem.imgPath != "")
                {
                    Sprite imageSprite = Resources.Load<Sprite>(journalItem.imgPath);
                    image.sprite = imageSprite;
                }

                gameObject.AddComponent<OnClickComponent>();
                var valueToInvoke = i;
                gameObject.GetComponent<OnClickComponent>().action = () => onItemSelectedCallback.Invoke(valueToInvoke);
                gameObject.GetComponent<OnClickComponent>().audioScript = audioScript;

                instantiatedJournalItems.Add(gameObject);
            }
        }

        public void clear()
        {
            journalItemContainer.transform.DetachChildren();
            foreach (var instantiatedJournalItem in instantiatedJournalItems)
            {
                Destroy(instantiatedJournalItem);
            }
        }

    }
}