using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Common;
using DefaultNamespace.Model;
using QuestScene.Repositories;
using UnityEngine;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class QuestInventoryPanelBehaviour : MonoBehaviour
    {
        public GameObject inventoryItemPrefab;
        public GameObject grid;

        public QuestInventoryTabsPanelBehaviour tabsPanelBehaviour; 

        public Text itemNameText;
        public Text itemDescriptionText;
        public Image itemImage;

        private List<GameObject> instantiatedItems = new List<GameObject>();

        public void Start()
        {
            GlobalSerializedState globalSerializedState = GlobalSerializedState.Get();
            List<StoredItem> storedItems = InventoryItemsRepository.getAllStoredItems();

            tabsPanelBehaviour.selectedGameType.Subscribe(gameType =>
            {
                Clear();
                ClearDisplayOfItem();
                
                var storedItemsOfNeededType = storedItems
                    .Where(v => v.Item.forWhatGame == gameType)
                    .Where(v => globalSerializedState.AddedInventoryItemIds.GetCopy().Contains(v.Item.id));

                foreach (var storedItem in storedItemsOfNeededType)
                {
                    var go = Instantiate(inventoryItemPrefab, grid.transform);
                    instantiatedItems.Add(go);

                    var questInventoryItemBehaviour = go.GetComponent<QuestInventoryItemBehaviour>();
                    questInventoryItemBehaviour.Display(storedItem, () => DisplayItem(storedItem));                    
                }
            }, true);
        }

        private void DisplayItem(StoredItem storedItem)
        {
            itemNameText.text = storedItem.Item.name;
            itemDescriptionText.text = storedItem.Item.description;
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = Resources.Load<Sprite>(storedItem.Item.imgPath);
        }

        private void Clear()
        {
            grid.transform.DetachChildren();

            foreach (var go in instantiatedItems)
            {
                Destroy(go);
            }
        }

        public void ClearDisplayOfItem()
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            itemImage.gameObject.SetActive(false);
        }
    }
}