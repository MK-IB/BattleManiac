using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using TMPro;

public class WinnerOrLoser : MonoBehaviour
{
    private string winText = "YOU WIN";
    private string loseText = "YOU LOSE";

    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private TextMeshProUGUI winLoseText;
    

    public GameObject playerKing;
    public GameObject enemyKing;
    public GameObject crown;

    private bool gameEnded = false;
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
            
        }
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
