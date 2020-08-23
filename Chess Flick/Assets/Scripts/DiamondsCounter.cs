using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondsCounter : MonoBehaviour
{

    public TextMeshProUGUI mainDiamondCounter;
    public TextMeshProUGUI skinDiamondCounter;
    public Animator diamondsImgAnimator;
    private int diamonds;

    void Start()
    {
      if(SceneManager.GetActiveScene().name == "Level 1")
      {
        diamonds = 1000;
        PlayerPrefsController.SetDiamonds(diamonds);
      }
      diamonds = PlayerPrefsController.GetDiamonds();
        UpdateDisplay();
    }

  private void UpdateDisplay()
  {
      if(!mainDiamondCounter || !skinDiamondCounter)
        return;
      mainDiamondCounter.SetText(PlayerPrefsController.GetDiamonds().ToString());
      skinDiamondCounter.SetText(PlayerPrefsController.GetDiamonds().ToString());
      Debug.Log("Diamonds=" + diamonds);
  }

  public bool HaveEnoughDiamonds(int amount)
  {
      return diamonds >= amount;
  }
  public void AddDiamonds(int amount)
  {
      diamonds += amount;
      PlayerPrefsController.SetDiamonds(diamonds);
      UpdateDisplay();
  }

  public void SpendDiamonds(int amount)
  {
      if(diamonds >= amount)
      {
        diamonds -= amount;
        PlayerPrefsController.SetDiamonds(diamonds);
        UpdateDisplay();
      }  
  }
    
    public void CollectDiamonds()
      {
         diamondsImgAnimator.SetBool("startDiamondsAnimation", true);
         int diamondsWon = FindObjectOfType<WinnerOrLoser>().totDiamondsWon;
         AddDiamonds(diamondsWon);
      }
}
