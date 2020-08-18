using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;





/*************
 * Step 1: ad google admob sdk https://developers.google.com/admob/unity/quick-start
 * Step 2: get the adunits for interstitial and rewarded ads
 * Step 3: to call the ad use "DisplayAd"
 * 
 * 
 * 
 * */

namespace GreenLightSudios
{

    public class AdsManager : MonoBehaviour
    {
        public static AdsManager myAdsManager;
        private BannerView adBanner;
        private InterstitialAd interstitial;
        private RewardedAd rewardedAd;

        public static event Action InterstialLoaded;


        //call this on your script, if it sends event that means user has watched the rewarded
        public static event Action RewardedVideoEarnedRewawrd;

        private void Awake()
        {
            if (myAdsManager != null)
            {
                Destroy(gameObject);
                return;

            }
            else
            {
                myAdsManager = this;
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            //initialize 
           // MobileAds.Initialize(initStatus => { });

            RequestInterstitial();
            CreateAndLoadRewardedAd();



        }

        #region RewardedVideoAd
        public void DisplayRewardedVideoAd()
        {
            if (rewardedAd.IsLoaded())
            {
                rewardedAd.Show();
            }
        }
        private void CreateAndLoadRewardedAd()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

            this.rewardedAd = new RewardedAd(adUnitId);

            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded ad with the request.
            this.rewardedAd.LoadAd(request);
        }



        public void HandleRewardedAdLoaded(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardedAdLoaded event received");
        }

      

        public void HandleRewardedAdOpening(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardedAdOpening event received");
        }

        public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
        {
            
        }

        public void HandleRewardedAdClosed(object sender, EventArgs args)
        {

            this.CreateAndLoadRewardedAd();
        }

        public void HandleUserEarnedReward(object sender, Reward args)
        {
            string type = args.Type;
            double amount = args.Amount;
            RewardedVideoEarnedRewawrd();


        }

        #endregion

        #region interstial_Ad
        public void DisplayAd()
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
                RequestInterstitial();
                InterstialLoaded();
            }
        }


        private void RequestInterstitial()
        {
            #if UNITY_ANDROID
                    string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // HERE ADD OUR INTERSTIALS
            #elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
                        string adUnitId = "unexpected_platform";
            #endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);

          
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }

        #endregion

    }
}