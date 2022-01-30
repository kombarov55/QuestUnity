using System.Collections.Generic;
using DefaultNamespace.model;
using DefaultNamespace.Service;
using QuestScene.Repositories;
using UnityEngine;

namespace QuestScene.Ui
{
    public class ShopPanelBehaviour : MonoBehaviour
    {
        public GameObject itemForSalePrefab;
        public GameObject grid;
        public ShopTabPanelBehaviour shopTabPanelBehaviour;

        private List<GameObject> _instantiatedGos = new List<GameObject>();
        
        public void Start()
        {
            shopTabPanelBehaviour.selectedGameType.Subscribe(gameType =>
            {
                Clear();
                
                List<InventoryItem> items = InventoryItemsRepository.FindItemsForSaleByGameType(gameType);

                foreach (var item in items)
                {
                    var go = Instantiate(itemForSalePrefab, grid.transform);
                    var itemForSaleBehaviour = go.GetComponent<ItemForSaleBehaviour>();
                    itemForSaleBehaviour.Display(item, () =>
                    {
                        if (ShopService.IsEnoughMoney(item))
                        {
                            ShopService.Purchase(item);
                            itemForSaleBehaviour.ShowFadingText("ОК");
                            ItemService.AddItemToInventory(item, 1);
                        }
                        else
                        {
                            itemForSaleBehaviour.ShowFadingText("Недостаточно денег");
                        }
                    });
                }
            }, true);
        }

        private void Clear()
        {
            grid.transform.DetachChildren();
            foreach (var go in _instantiatedGos)
            {
                Destroy(go);
            }
            
            _instantiatedGos.Clear();
        }
        
    }
}