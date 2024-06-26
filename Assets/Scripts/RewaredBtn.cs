using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewaredBtn : MonoBehaviour
{
    public void ShowRewardedAds()
    {
        AdsManager.Instance.rewardedAds.ShowRewardedAd();
    }
}
