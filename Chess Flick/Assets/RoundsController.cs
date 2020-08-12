using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundsController : MonoBehaviour
{
   public bool finishLineTouched = false;
   public int roundCompleted = 0;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            finishLineTouched = true;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
