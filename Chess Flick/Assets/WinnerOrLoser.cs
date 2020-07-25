using UnityEngine.UI;
using UnityEngine;

public class WinnerOrLoser : MonoBehaviour
{
    private string winText = "YOU WIN";
    private string loseText = "YOU LOSE";

    [SerializeField] private GameObject winLoseCanvas;
    [SerializeField] private Image winLoseBG;
    [SerializeField] private Text winLoseText;

    private void Awake()
    {
        if(!winLoseCanvas)
            return;
        winLoseCanvas.SetActive(false);
    }

   public void WinOrLose(string tag)
    {
        if(tag == "playerKing")
            HandleLoseCondition();
        else   
            HandleWinCondition();
    }
    public void HandleLoseCondition()
    {
        Debug.Log("You Lose");
        winLoseCanvas.SetActive(true);
        winLoseBG.color = Color.red;
        winLoseText.text = loseText;

        FindObjectOfType<Movement>().state = BattleState.LOST;
    }

    public void HandleWinCondition()
    {
        Debug.Log("You Win");
        winLoseCanvas.SetActive(true);
        winLoseBG.color = Color.white;
        winLoseText.text = winText;
    }
}
