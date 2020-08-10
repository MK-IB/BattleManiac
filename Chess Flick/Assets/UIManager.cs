using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject skinSelectionPanel;
    public TextMeshProUGUI levelText;

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

   
}
