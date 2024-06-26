using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId = "5645136";
    [SerializeField] private string iosAdUnitId = "5645137";

    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
            adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
            adUnitId = androidAdUnitId;
#endif
        adUnitId = androidAdUnitId;
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadRewardedAd();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Рекламное видео загружено...");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Ошибка загрузки рекламного видео: {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Ошибка показа рекламного видео: {error} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Рекламное видео полностью просмотрено");

            PlayerPrefs.SetInt("CarCoins", PlayerPrefs.GetInt("CarCoins") + Int32.Parse(GameObject.Find("Count Money Level").GetComponent<Text>().text));
            
            Text tempText = GameObject.Find("Count Money").GetComponent<Text>();
            tempText.text = PlayerPrefs.GetInt("CarCoins").ToString();

            GameManager.Instance.isRewared = true;
            GameManager.Instance.ResetGame();
        }
    }
}
