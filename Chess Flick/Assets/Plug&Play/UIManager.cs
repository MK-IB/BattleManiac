using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GreenLightSudios;

public class UIManager : MonoBehaviour
{
    public Text notificationText;

    private void OnEnable()
    {
        AdsManager.InterstialLoaded += AdsManager_InterstialLoaded;
        AdsManager.RewardedVideoEarnedRewawrd += AdsManager_RewardedVideoEarnedRewawrd;
    }
    private void OnDisable()
    {

        AdsManager.InterstialLoaded -= AdsManager_InterstialLoaded;
        AdsManager.RewardedVideoEarnedRewawrd -= AdsManager_RewardedVideoEarnedRewawrd;

    }
    private void AdsManager_RewardedVideoEarnedRewawrd()
    {
        
        //call back        
        notificationText.text = "Give User a reward";



    }

 

    private void AdsManager_InterstialLoaded()
    {
        notificationText.text = "Interstitial Loaded";
    }

    public void ShowInterStitial()
    {
        //call display ad
        AdsManager.myAdsManager.DisplayAd();
    }


    public void ShowRewardedAd()
    {
        // call rewarded video ad
        AdsManager.myAdsManager.DisplayRewardedVideoAd();
    }
}
