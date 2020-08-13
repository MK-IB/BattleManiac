using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class WinnerOrLoser : MonoBehaviour
{
    private string winText = "YOU WIN";
    private string loseText = "YOU LOSE";

    public Transform slab2;
    public Transform slab3;

    public List<GameObject> target3;
    public List<GameObject> target4;
    public List<GameObject> target5;

    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private TextMeshProUGUI winLoseText;
    

    public GameObject playerKing;
    public GameObject enemyKing;
    public GameObject crown;

    private bool gameEnded = false;
    private string roundInfo;

    private int barrierNum;
    private void Awake()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

   public void WinOrLose(string tag)
    {
        if(tag == "playerKing")
        {
            HandleLoseCondition();
        }

        if(tag == "enemyKing" && FindObjectOfType<RoundsController>().finishLineTouched)
        {
            HandleWinCondition();
        }
        else if(tag == "enemyKing" && FindObjectOfType<RoundsController>().roundCompleted == 1)
        {
            //show the RPOUND COMPLETED UI
            FindObjectOfType<UIManager>().ShowRoun1dCompleteUI();
        }

         else if(tag == "enemyKing" && FindObjectOfType<RoundsController>().roundCompleted == 2)
        {
            roundInfo = "Round 2 Complete";
            FindObjectOfType<UIManager>().ShowRound2CompleteUI();

           
        }
    }

    public void ProceedRound2()
    {
        //start slab 2 animation + slide pawns to target 3
        FindObjectOfType<FollowKing>().enabled = true;
        FindObjectOfType<BattleHandler>().DestroyTheEnemies();
        barrierNum = 2;
        FindObjectOfType<AnimationController>().SlabExpandAnimation(slab2, target3, barrierNum);
    }

    public void ProceedRound3()
    {
         //start slab 2 animation + slide pawns to target 3
        FindObjectOfType<FollowKing>().enabled = true;
        FindObjectOfType<BattleHandler>().DestroyTheEnemies();
        barrierNum = 3;
        FindObjectOfType<AnimationController>().SlabExpandAnimation(slab3, target4, barrierNum);
    }
    public void HandleLoseCondition()
    {
        Debug.Log("You lost");
        loseCanvas.SetActive(true);
    }

    public void HandleWinCondition()
    {
        Debug.Log("You Win");
        winCanvas.SetActive(true);
    }

    //calling from the diamonds img animation event !
    public void HideWinCanvas()
    {
        winCanvas.SetActive(false);
    }
    IEnumerator CrownAnimation()
    {
        //Vector3 pos = new Vector4(playerKing.transform.position.x, playerKing.transform.position.y + 0.25f, playerKing.transform.position.z);
        //Instantiate(crown, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
         
    }
}
