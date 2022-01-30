using System;
using DefaultNamespace;
using DefaultNamespace.Common.UI;
using DefaultNamespace.model;
using UnityEngine;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class ItemForSaleBehaviour : MonoBehaviour
    {
        public Image image;
        public Text nameText;
        public Text descriptionText;
        public Text priceText;
        public Text forWhatGameText;
        public AudioButton buyButton;
        public GameObject notEnoughMoneyText;

        public void Display(InventoryItem item, Action onClick)
        {
            image.sprite = Resources.Load<Sprite>(item.imgPath);
            nameText.text = item.name;
            descriptionText.text = item.description;
            priceText.text = item.price.ToString();
            forWhatGameText.text = forWhatGameToRussian(item.forWhatGame);
            buyButton.OnClick = onClick;
        }
        
        public void ShowFadingText(string text)
        {
            var go = Instantiate(notEnoughMoneyText, buyButton.transform);
            go.SetActive(true);
            go.transform.position.Set(0, 40, 0);
            go.GetComponent<Text>().text = text;
            var moveBehaviour = go.GetComponent<MoveBehaviour>();
            var fadingOutBehaviour = go.GetComponent<FadingOutBehaviour>();
            
            moveBehaviour.Run();
            fadingOutBehaviour.Run();
            
            Context.AudioScript().PlayCoin1();

            Destroy(go, fadingOutBehaviour.durationInSeconds);
        }

        private string forWhatGameToRussian(InventoryItemGameType gameType)
        {
            switch (gameType)
            {
                case InventoryItemGameType.Alchemy:
                    return "Варка зелий";
                case InventoryItemGameType.Quest:
                    return "Квест";
                case InventoryItemGameType.ThreeInARow:
                    return "3 в ряд";
                default: 
                    return "Слава Сатане";
            }
        }

    }
}