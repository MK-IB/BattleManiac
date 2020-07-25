using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsCanvas;

    private void Awake()
    {
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
