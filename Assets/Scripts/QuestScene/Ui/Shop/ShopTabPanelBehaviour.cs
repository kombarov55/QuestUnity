using DefaultNamespace.Common;
using DefaultNamespace.model;
using UnityEngine;

namespace QuestScene.Ui
{
    public class ShopTabPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioButton threeInARowTab;
        [SerializeField] private AudioButton alchemyTab;

        public Observable<InventoryItemGameType> selectedGameType = new Observable<InventoryItemGameType>(InventoryItemGameType.ThreeInARow);
        
        public void Start()
        {
            threeInARowTab.OnClick = () => selectedGameType.Value = InventoryItemGameType.ThreeInARow;
            alchemyTab.OnClick = () => selectedGameType.Value = InventoryItemGameType.Alchemy;
        }
    }
}