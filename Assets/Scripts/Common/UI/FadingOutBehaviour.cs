using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Common.UI
{
    public class FadingOutBehaviour : MonoBehaviour
    {
        public float durationInSeconds = 1;

        public void Run()
        {
            var text = GetComponent<Text>();
            if (text != null)
            {
                StartCoroutine(UICoroutines.FadeTextToZeroAlpha(text, durationInSeconds));
            }
            else
            {
                var image = GetComponent<Image>();
                if (image != null)
                {
                    StartCoroutine(UICoroutines.FadeImageToZeroAlpha(image, durationInSeconds));
                }
            }
        }
    }
}