using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject skinSelectionPanel;
    [SerializeField] private GameObject round1CompleteUIPanel;
    [SerializeField] private GameObject round2CompleteUIPanel;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI roundInfo;

    private void Awake()
    {
        if(!settingsPanel || !skinSelectionPanel)
            return;
        settingsPanel.SetActive(false);
        skinSelectionPanel.SetActive(false);
    }
    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    public void ShowSkinsPanel()
    {
        skinSelectionPanel.SetActive(true);
    }

    public void HideSkinsPanel()
    {
        skinSelectionPanel.SetActive(false);
    }

    //ROUNDS UI CONTROLLER
    public void ShowRoun1dCompleteUI()
    {
        round1CompleteUIPanel.SetActive(true);
    }
    public void ShowRound2CompleteUI()
    {
        round2CompleteUIPanel.SetActive(true);
    }

    //HIDDING THE ROUNDS UI
    public void HideRound1CompleteUI(string str)
    {
        round1CompleteUIPanel.SetActive(false);
        FindObjectOfType<WinnerOrLoser>().ProceedRound2();
    }

    public void HideRound2CompleteUI(string str)
    {
        round2CompleteUIPanel.SetActive(false);
    }

   
}
