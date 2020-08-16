using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

namespace GreenLightSudios
{
    /***
     * 
     * Download GA: http://download.gameanalytics.com/unity/GA_SDK_UNITY.unitypackage
     * 
     * 
     * 
     * 
     * 
     * 
     * ***/


    public class AnalyticsManager : MonoBehaviour
    {
        public static AnalyticsManager myAnalyticsManager;
        private void Awake()
        {
            if (myAnalyticsManager != null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                myAnalyticsManager = this;
            }
            GameAnalytics.Initialize();

            DontDestroyOnLoad(gameObject);

        }


        public void LevelOver(string level_name)
        {

            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level_name);

        }

        public void LevelComplete(string level_name) {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level_name);

        }
        public void LevelStart(string level_name)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level_name);

        }

    }
}