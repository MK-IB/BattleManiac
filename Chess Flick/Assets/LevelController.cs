using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    void Start()
    {
        int sceneToLoad = PlayerPrefsController.GetSavedLevel();
        //Debug.Log("Scene tO load:"+ sceneToLoad);
        //SceneManager.LoadScene(sceneToLoad);
    }
   public void LoadNextLevel()
   {
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
