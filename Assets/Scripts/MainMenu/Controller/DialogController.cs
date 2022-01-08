using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class DialogController : MonoBehaviour
    {
        private void Start()
        {
            var go = gameObject;
            AudioButton closeDialogButton = GameObject.Find("CloseDialogButton").GetComponent<AudioButton>();
            closeDialogButton.OnClick = () => go.SetActive(false);
        }
    }
}