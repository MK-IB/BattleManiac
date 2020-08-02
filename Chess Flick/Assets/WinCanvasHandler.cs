using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasHandler : MonoBehaviour
{
    public GameObject winCanvas;

    public void HideWinCanvas()
    {
        FindObjectOfType<WinnerOrLoser>().HideWinCanvas();
        FindObjectOfType<LevelController>().LoadNextLevel();
    }
}
