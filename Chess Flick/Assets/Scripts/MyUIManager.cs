using TMPro;
using UnityEngine;

public class MyUIManager : MonoBehaviour
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
        if(!round1CompleteUIPanel) return;
        round1CompleteUIPanel.SetActive(false);
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
        skinSelectionPanel.SetActive(true);
    }

    public void HideSkinsPanel()
    {
        skinSelectionPanel.SetActive(false);
    }

    //ROUNDS UI CONTROLLER
    public void ShowRoundCompleteUI()
    {
        round1CompleteUIPanel.SetActive(true);
    }
    public void ShowRound2CompleteUI()
    {
        round2CompleteUIPanel.SetActive(true);
    }

    //HIDDING THE ROUNDS UI
    public void HideRoundCompleteUI()
    {
        round1CompleteUIPanel.SetActive(false);
        //FindObjectOfType<WinnerOrLoser>().ProceedRound2();
    }

    public void HideRound2CompleteUI()
    {
        round2CompleteUIPanel.SetActive(false);
    }

   
}
