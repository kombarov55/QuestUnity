using System.Collections.Generic;
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

        public Text itemNameText;
        public Text itemDescriptionText;
        public Image itemImage;

        private List<GameObject> instantiatedItems = new List<GameObject>();

        public void Start()
        {
            Clear();
            ClearDisplayOfItem();

            List<StoredItem> storedItems = InventoryItemsRepository.getAllStoredItems();
            foreach (var storedItem in storedItems)
            {
                var go = Instantiate(inventoryItemPrefab, grid.transform);
                instantiatedItems.Add(go);

                var questInventoryItemBehaviour = go.GetComponent<QuestInventoryItemBehaviour>();
                questInventoryItemBehaviour.Display(storedItem, () => DisplayItem(storedItem));
            }
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