using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        
    }

    public void PauseTheGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeTheGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

   public void LoadNextLevel()
   {
       //FindObjectOfType<Admob>().ShowInterstitialAd();
       int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);  
        PlayerPrefsController.SetSavedLevel(nextScene);
   }

   public void LoadSameLevel()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void DeleteAllPrefsData()
   {
       PlayerPrefsController.ResetAll();
       int num = 0;
       PlayerPrefsController.SetNumOfPawnsBought(num);
       PlayerPrefsController.SetTilesCounter(num);
       PlayerPrefsController.SetSavedLevel(num);

   }
}
