using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class HeartCounterBehaviour : MonoBehaviour
    {
        private void Start()
        {
            CachedUserData cachedUserData = CachedUserData.Get();
            Text text = GetComponent<Text>();
            text.text = "x " + cachedUserData.ThreeInARowLifes;
        }
    }
}