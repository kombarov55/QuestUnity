using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace.Panels.InventoryPanel
{
    public class InventoryPanelController : MonoBehaviour
    {
        private AudioScript audioScript;
        
        private InventoryPanelPresenter inventoryPanelPresenter;

        public void Start()
        {
            inventoryPanelPresenter = GetComponent<InventoryPanelPresenter>();
            inventoryPanelPresenter.setOnItemClickedCallback(item => onItemClicked(item));
        }
        
        public void init(AudioScript audioScript, QuestSceneFlow questSceneFlow)
        {
            Start();
            this.audioScript = audioScript;
            inventoryPanelPresenter.init(audioScript, questSceneFlow);
        }

        public void show(List<InventoryItem> items)
        {
            inventoryPanelPresenter.addGridItems(items);
        }

        private void onItemClicked(InventoryItem item)
        {
            inventoryPanelPresenter.setNameText(item.name);
            inventoryPanelPresenter.setDescripionText(item.description);
        }
         
    }
}