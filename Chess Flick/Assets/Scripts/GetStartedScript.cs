using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetStartedScript : MonoBehaviour
{
    public Transform panel;
    public float offset;
    
    private float dur = 1.5f;
    void Start()
    {
        panel.DOScaleY(offset, dur);
    }

   public void GetStarted()
   {
       int leveToLoad = PlayerPrefsController.GetSavedLevel();
       SceneManager.LoadScene(leveToLoad + 1);
   }
}
