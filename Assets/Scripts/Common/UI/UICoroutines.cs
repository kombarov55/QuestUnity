using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Common.UI
{
    public static class UICoroutines
    {

        public static IEnumerator FadeTextToZeroAlpha(Text text, float duration)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / duration));
                yield return null;
            }
        }
        
        public static IEnumerator FadeImageToZeroAlpha(Image image, float duration)
        {
            while (image.color.a > 0.0f)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / duration));
                yield return null;
            }
        }
        
        public static IEnumerator FadeImageToFullAlpha(Image image, float duration)
        {
            while (image.color.a < 1f)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / duration));
                yield return null;
            }
        }

        public static IEnumerator InvokeAfterDelay(float durationInSeconds, Action action)
        {
            yield return new WaitForSeconds(durationInSeconds);
            action.Invoke();
        }
    }
}