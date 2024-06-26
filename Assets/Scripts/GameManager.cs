using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Logo, PlayImage, CountMoves, LoseText, WinText, ShopImage, CountMoneyLevel, CoinsLevel, ButtonRewardedAd;

    public int gamePlayed = 1, moneyForLevel = 0;

    public bool isRewared = false;

    public string CurrentCity;

    public bool IsGameStarted { get; private set; } = false;
    private bool IsLoseGame = false, IsWinGame = false;

    private void Awake()
    {
        CurrentCity = PlayerPrefs.GetString("CurrentCity", "City");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(DisplayBannerWithDelay());
    }

    private IEnumerator DisplayBannerWithDelay()
    {

        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlayGame()
    {
        Debug.Log(IsLoseGame);
        Debug.Log(IsWinGame);
        if (!IsLoseGame && !IsWinGame)
        {
            IsGameStarted = true;
            SetUIElements(false);
        }
        else
        {
            Debug.Log("Зашел в ресет");
            ResetGame();

            AdsManager.Instance.bannerAds.ShowBannerAd();
        }
    }

    public void WinGame()
    {
        Debug.Log("Победил");
        IsWinGame = true;
        IsGameStarted = false;
        SetUIElements(true);
        WinText.SetActive(true);
        ShopImage.SetActive(true);
        CountMoneyLevel.SetActive(true);
        CoinsLevel.SetActive(true);
        CountMoneyLevel.GetComponent<Text>().text = moneyForLevel.ToString();
        ButtonRewardedAd.SetActive(true);

        AdsManager.Instance.bannerAds.HideBannerAd();

        int currentLevel = PlayerPrefs.GetInt("Game Level");
        int nextLevel = (currentLevel % 2) + 1;
        PlayerPrefs.SetInt("Game Level", nextLevel);

        //Invoke("LoadNextLevel", 100f);
    }

    public void LoseGame()
    {
        Debug.Log("Проиграл");
        IsLoseGame = true;
        IsGameStarted = false;
        SetUIElements(true);
        LoseText.SetActive(true);
        CountMoneyLevel.SetActive(true);
        CoinsLevel.SetActive(true);
        CountMoneyLevel.GetComponent<Text>().text = moneyForLevel.ToString();
        ButtonRewardedAd.SetActive(true);


        AdsManager.Instance.bannerAds.HideBannerAd();

        
    }

    private void LoadNextLevel()
    {
        Debug.Log("Запустил уровень");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIElements();
        SetUIElements(!IsGameStarted);
    }

    private void FindUIElements()
    {
        Logo = GameObject.Find("Logo");
        PlayImage = GameObject.Find("PlayImage");
        CountMoves = GameObject.Find("CountMoves");
        LoseText = GameObject.Find("LoseText");
        WinText = GameObject.Find("WinText");
        ShopImage = GameObject.Find("ShopImage");
    }

    private void SetUIElements(bool showStartUI)
    {
        if (Logo != null) Logo.SetActive(showStartUI);
        if (PlayImage != null) PlayImage.SetActive(showStartUI);
        if (CountMoves != null) CountMoves.SetActive(!showStartUI);
        if (LoseText != null) LoseText.SetActive(false);
        if (WinText != null) WinText.SetActive(false);
        if (ShopImage != null) ShopImage.SetActive(false);
        if (CountMoneyLevel != null) CountMoneyLevel.SetActive(false);
        if (CoinsLevel != null) CoinsLevel.SetActive(false);
        if (ButtonRewardedAd != null) ButtonRewardedAd.SetActive(false);

    }

    public void ResetGame()
    {
        AdsManager.Instance.interstitialAds.ShowInterstitialAd();
        gamePlayed++;

        IsGameStarted = false;
        IsLoseGame = false;
        IsWinGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
