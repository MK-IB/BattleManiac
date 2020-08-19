using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyUIManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject skinSelectionPanel;
    [SerializeField] private GameObject round1CompleteUIPanel;
    [SerializeField] private GameObject round2CompleteUIPanel;

    public TextMeshProUGUI levelText;
    public Button tileBuyButton;

    public bool isUIActive = false;

    private List<GameObject> gradButtons;

    private void Awake()
    {
        if(!settingsPanel || !skinSelectionPanel)
            return;
        settingsPanel.SetActive(false);
        skinSelectionPanel.SetActive(false);
        if(!round1CompleteUIPanel) return;
        round1CompleteUIPanel.SetActive(false);

         if(SceneManager.GetActiveScene().buildIndex >= 9)
            tileBuyButton.interactable = true;
        else tileBuyButton.interactable = false;
        
        
    }

    private void Start()
    {
        

    }
    public void ShowSettingsPanel()
    {
        FindObjectOfType<AnimationController>().HideMainUI();
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
        FindObjectOfType<AnimationController>().ShowMainUI();
    }
    public void ShowSkinsPanel()
    {
        isUIActive = true;
        skinSelectionPanel.SetActive(true);
        gradButtons = new List<GameObject>(GameObject.FindGameObjectsWithTag("gradButton"));
        Debug.Log("Grad buttons size:" + gradButtons.Count);
        if(SceneManager.GetActiveScene().buildIndex >=14)
        {
            foreach(GameObject btn in gradButtons) btn.GetComponent<Button>().interactable = true;
        } else foreach(GameObject btn in gradButtons) btn.GetComponent<Button>().interactable = false;
    }

    public void HideSkinsPanel()
    {
        isUIActive = false;
        skinSelectionPanel.SetActive(false);
    }

    //ROUNDS UI CONTROLLER
    public void ShowRoundCompleteUI()
    {
        isUIActive = true;
        round1CompleteUIPanel.SetActive(true);
    }
    public void ShowRound2CompleteUI()
    {
        round2CompleteUIPanel.SetActive(true);
    }

    //HIDDING THE ROUNDS UI
    public void HideRoundCompleteUI()
    {
        isUIActive = false;
        round1CompleteUIPanel.SetActive(false);
        //FindObjectOfType<WinnerOrLoser>().ProceedRound2();
    }

    public void HideRound2CompleteUI()
    {
        round2CompleteUIPanel.SetActive(false);
    }

   
}
