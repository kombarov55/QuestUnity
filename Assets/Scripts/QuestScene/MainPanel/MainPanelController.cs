using UnityEngine;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelController : MonoBehaviour
    {
        private MainPanelPresenter mainPanelPresenter;
        private CachedUserData cachedUserData;

        public void init(CachedUserData cachedUserData)
        {
            this.cachedUserData = cachedUserData;
            
            mainPanelPresenter = GetComponent<MainPanelPresenter>();
            mainPanelPresenter.setCoinCountText(cachedUserData.coinCount);
        }

        public void decrementCoinCount()
        {
            if (cachedUserData.coinCount >= 1)
            {
                cachedUserData.coinCount = cachedUserData.coinCount - 1;
                mainPanelPresenter.setCoinCountText(cachedUserData.coinCount);
            }
        }
    }
}