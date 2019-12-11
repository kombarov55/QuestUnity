using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CachedUserData : MonoBehaviour
    {
        public string currentSceneId;
        public int coinCount = 5;

        public List<string> openedJournalItems = new List<string>();
    }
}