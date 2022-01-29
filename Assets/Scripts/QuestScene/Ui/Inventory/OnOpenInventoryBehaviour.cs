using System.Collections.Generic;
using DefaultNamespace.Common;
using UnityEngine;

namespace QuestScene.Ui
{
    public class OnOpenInventoryBehaviour : MonoBehaviour
    {
        public void Run()
        {
            GlobalSerializedState.Get().UnseenInventoryItemIds.SetValues(new List<string>());
        }
    }
}