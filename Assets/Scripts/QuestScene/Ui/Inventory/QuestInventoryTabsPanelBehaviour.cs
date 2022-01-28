using DefaultNamespace.Common;
using DefaultNamespace.model;
using UnityEngine;

namespace QuestScene.Ui
{
    public class QuestInventoryTabsPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private QuestInventoryTabBehaviour questTab;
        [SerializeField] private QuestInventoryTabBehaviour threeInARowTab;
        [SerializeField] private QuestInventoryTabBehaviour alchemyTab;

        //WARNING: начальное значение не связано с эдитором
        public Observable<InventoryItemGameType> selectedGameType = new Observable<InventoryItemGameType>(InventoryItemGameType.Quest); 
        
        public void Start()
        {
            questTab.OnSelected.Subscribe(() => selectedGameType.Value = InventoryItemGameType.Quest);
            threeInARowTab.OnSelected.Subscribe(() => selectedGameType.Value = InventoryItemGameType.ThreeInARow);
            alchemyTab.OnSelected.Subscribe(() => selectedGameType.Value = InventoryItemGameType.Alchemy);
        }
    }
}