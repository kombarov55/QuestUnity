using System;
using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Panels.InventoryPanel
{
    public class InventoryPanelPresenter : MonoBehaviour
    {
        public Text name;
        public Text description;

        public GameObject grid;

        public GameObject itemPrefab;

        private AudioScript audioScript;
        private QuestSceneFlow questSceneFlow;

        private Action<InventoryItem> onItemClickedCallback;
        private List<GameObject> gameObjects = new List<GameObject>();

        public void init(AudioScript audioScript, QuestSceneFlow questSceneFlow)
        {
            this.audioScript = audioScript;
            this.questSceneFlow = questSceneFlow;
        }
        
        public void setOnItemClickedCallback(Action<InventoryItem> onItemClickedCallback)
        {
            this.onItemClickedCallback = onItemClickedCallback;
        }
        
        public void setNameText(string str)
        {
            name.text = str;
        }

        public void setDescripionText(string str)
        {
            description.text = str;
        }

        public void addGridItems(List<InventoryItem> items)
        {
            clear();
            foreach (var item in items)
            {
                var gameObject = Instantiate(itemPrefab, grid.transform);
                gameObjects.Add(gameObject);
                var sprite = Resources.Load<Sprite>(item.imgPath);
                gameObject.GetComponent<Image>().sprite = sprite;
                gameObject.AddComponent<OnClickComponent>();
                var itemToPass = item;
                gameObject.GetComponent<OnClickComponent>().action = () => onItemClickedCallback.Invoke(itemToPass);
                gameObject.GetComponent<OnClickComponent>().audioScript = audioScript;
            }
        } 

        public void clear()
        {
            grid.transform.DetachChildren();
            foreach (var gameObject in gameObjects)
            {
                Destroy(gameObject);
            }
        }

        public void onBackClicked()
        {
            clear();
            questSceneFlow.hideInventoryPanel();
            questSceneFlow.showQuestScene();
        }

        public void playOnClickSound()
        {
            audioScript.PlayButtonClickSound();
        }

    }
}