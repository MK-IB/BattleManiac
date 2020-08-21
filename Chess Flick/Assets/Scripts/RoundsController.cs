using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundsController : MonoBehaviour
{
   public bool finishLineTouched = false;
   public int roundCompleted = 0;

   public List<Image> indicators;
   private int counter = 0;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            finishLineTouched = true;
        }
        
    }

    public void ShowRoundIndicator()
    {
        if(indicators.Count < 1) return;
        else
        {
            indicators[counter].color = Color.yellow;
            counter += 1;
        }
        
    }

    public bool GetFinishLineTouched()
    {
        return finishLineTouched; 
    }
    public int GetRoundsCompleted()
    {
        return roundCompleted;
    }

    public void SetRoundsCompleted(int num)
    {
        roundCompleted = num;
    }
}
