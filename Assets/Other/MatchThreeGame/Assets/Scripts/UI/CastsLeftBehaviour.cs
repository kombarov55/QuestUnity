﻿using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class CastsLeftBehaviour : MonoBehaviour
    {
        public bool isForPlayer;
        public GameObject counterImage1;
        public GameObject counterImage2;
        public GameObject counterImage3;
        public Text largeAmountCounterText;
        public GameObject largeAmountCounterImage;

        public void Start()
        {
            StateManager stateManager = StateManager.Get();

            Observable<int> observable = isForPlayer ? stateManager.CastsLeftForPlayer : stateManager.CastsLeftForEnemy;

            Debug.Log("Subscribed");
            
            observable.Subscribe(amount =>
            {
                Debug.Log("Tick " + amount);
                switch (amount)
                {
                    case 0:
                        counterImage1.SetActive(false);
                        counterImage2.SetActive(false);
                        counterImage3.SetActive(false);
                        largeAmountCounterImage.SetActive(false);
                        largeAmountCounterText.gameObject.SetActive(false);
                        break;
                    case 1:
                        counterImage1.SetActive(true);
                        counterImage2.SetActive(false);
                        counterImage3.SetActive(false);
                        largeAmountCounterImage.SetActive(false);
                        largeAmountCounterText.gameObject.SetActive(false);
                        break;
                    case 2:
                        counterImage1.SetActive(true);
                        counterImage2.SetActive(true);
                        counterImage3.SetActive(false);
                        largeAmountCounterImage.SetActive(false);
                        largeAmountCounterText.gameObject.SetActive(false);
                        break;
                    case 3:
                        counterImage1.SetActive(true);
                        counterImage2.SetActive(true);
                        counterImage3.SetActive(true);
                        largeAmountCounterImage.SetActive(false);
                        largeAmountCounterText.gameObject.SetActive(false);
                        break;
                    default:
                        counterImage1.SetActive(false);
                        counterImage2.SetActive(false);
                        counterImage3.SetActive(false);
                        largeAmountCounterImage.SetActive(true);
                        largeAmountCounterText.gameObject.SetActive(true);
                        largeAmountCounterText.text = "x" + amount;
                        break;
                }
            }, true);
        }
    }
}