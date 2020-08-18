using UnityEngine.SceneManagement;
using UnityEngine;

public class WinCanvasHandler : MonoBehaviour
{
    public GameObject winCanvas;

    public void HideWinCanvas()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
         {
           FindObjectOfType<LevelUpController>().ShowLargeGroundCanv();
         }

         else if(SceneManager.GetActiveScene().name == "Level 3")
         {
           FindObjectOfType<LevelUpController>().ShowCircGroundCanv();
         }

         else if(SceneManager.GetActiveScene().name == "Level 4")
         {
           FindObjectOfType<LevelUpController>().ShowLargeBarrierCanv();
         }

         else if(SceneManager.GetActiveScene().name == "Level 5")
         {
           FindObjectOfType<LevelUpController>().ShowGreenEnvCanv();
         }
        
        else if(SceneManager.GetActiveScene().name == "Level 7")
         {
           FindObjectOfType<LevelUpController>().ShowLargeGroundCanv();
         }
         else if(SceneManager.GetActiveScene().name == "Level 10")
         {
           FindObjectOfType<LevelUpController>().ShowDesertEnvCanv();
         }

         else if(SceneManager.GetActiveScene().name == "Level 12")
         {
           FindObjectOfType<LevelUpController>().ShowPolyGroundCanv();
         }
         else{
             FindObjectOfType<WinnerOrLoser>().HideWinCanvas();
             FindObjectOfType<LevelController>().LoadNextLevel();
         }
    }
}
