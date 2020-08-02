using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
   public void LoadNextLevel()
   {
        SceneManager.LoadScene(currentSceneIndex + 1);  
        PlayerPrefsController.SetSavedLevel(currentSceneIndex + 1);
   }

   public void LoadSameLevel()
   {
       SceneManager.LoadScene(currentSceneIndex);
   }
}
