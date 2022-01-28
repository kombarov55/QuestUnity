using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.Common.UI
{
    public class LoadingPanelBehaviour : MonoBehaviour
    {
        public Text text;
        public Slider slider;

        public void LoadScene(string sceneName)
        {
            gameObject.SetActive(true);
            StartCoroutine(InternalStartLoading(sceneName));
        }

        private IEnumerator InternalStartLoading(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncOperation.isDone)
            {
                Debug.Log(asyncOperation.progress);
                slider.value = asyncOperation.progress;
                yield return null;
            }
        }
    }
}