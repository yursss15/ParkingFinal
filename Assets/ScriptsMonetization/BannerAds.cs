using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;

    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
            adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
            adUnitId = androidAdUnitId;
#endif

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    private void BannerLoadedError(string message)
    {
        Debug.LogError($"Ошибка загрузки баннерной рекламы: {message}");
    }

    private void BannerLoaded()
    {
        Debug.Log("Баннерная реклама загружена");
    }

    public void ShowBannerAd()
    {
        Debug.Log("Htrkfvf jnjhfbpbkfcm))");
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    private void BannerHidden() { }
    private void BannerClicked() { }
    private void BannerShown() { }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}
