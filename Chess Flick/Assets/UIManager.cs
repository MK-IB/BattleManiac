using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsCanvas;

    public TextMeshProUGUI levelText;

    private void Awake()
    {
        levelText.SetText("Level " + PlayerPrefsController.GetSavedLevel());
        if(!settingsCanvas)
            return;
        settingsCanvas.SetActive(false);
    }
    public void ShowSettingsPanel()
    {
        settingsCanvas.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        settingsCanvas.SetActive(false);
    }
}
