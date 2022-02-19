using System;
using DefaultNamespace.Common;
using DefaultNamespace.model;
using UnityEngine;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class ItemTypeDropdownListener : MonoBehaviour
    {

        public Observable<InventoryItemGameType> SelectedGameType =
            new Observable<InventoryItemGameType>(InventoryItemGameType.ThreeInARow); 
        
        public void Start()
        {
            var dropdown = GetComponent<Dropdown>();
            dropdown.onValueChanged.AddListener(delegate
            {
                SelectedGameType.Emit(GetGameTypeByString(dropdown.options[dropdown.value].text));
            });
            
            SelectedGameType.Emit(GetGameTypeByString(dropdown.options[dropdown.value].text));
        }

        private InventoryItemGameType GetGameTypeByString(string s)
        {
            switch (s)
            {
                case "3 в ряд":
                    return InventoryItemGameType.ThreeInARow;
                case "Квест":
                    return InventoryItemGameType.Quest;
                case "Алхимия":
                    return InventoryItemGameType.Alchemy;
                default: throw new Exception();
            }
        }

    }
}