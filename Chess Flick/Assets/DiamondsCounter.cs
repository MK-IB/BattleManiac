using TMPro;
using UnityEngine;

public class DiamondsCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI diamondText;
    private int diamonds = 0;

    void Start()
    {
        diamonds = PlayerPrefsController.GetDiamonds();
        UpdateDisplay();
        Debug.Log("Diamonds=" + PlayerPrefsController.GetDiamonds());
    }

  private void UpdateDisplay()
  {
      diamondText.SetText(PlayerPrefsController.GetDiamonds().ToString());
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
    
}
