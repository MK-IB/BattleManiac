using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    private float AnimWaitTime = 1.5f;
    public Transform slab1;
    private Transform slabTemp;
    
    public Animator CameraAnimator;
    public GameObject mainUI;
    private float mainUIOffset = 360f;

    void Start()
    {
        FindObjectOfType<MyUIManager>().isUIActive = true;
        if(mainUI) mainUI.SetActive(true);
    }
    public List<GameObject> target2;
    public void StartTheGame()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            HideMainUI();
            FindObjectOfType<GrundController>().ShowUpBarrier(1);
        }
        else
        {
            HideMainUI();
            SlabExpandAnimation(slab1, target2, 1); //will call the pawns sliding animation
        }
         
    }

    public void HideMainUI()
    {
        FindObjectOfType<MyUIManager>().isUIActive = false;
       mainUI.SetActive(false);
    }

    public void ShowMainUI()
    {
        FindObjectOfType<MyUIManager>().isUIActive = false;
        mainUI.SetActive(true);
    }
     
     //animating the players towards the play ground
    public void CameraAnimation()
    {
        CameraAnimator.SetBool("cameraAnimation", true);

    }

    public void DestroyTheAnimatedObjects()
    {
        
    
    }
    public void SlabExpandAnimation(Transform slab, List<GameObject> target, int barrierNum)
    {
        slabTemp = slab;
        Vector3 scaleTo = new Vector3(1.6f, 0.11f, 3.98f);
        slabTemp.DOScale(scaleTo, 1f).OnComplete(()=> {
            FindObjectOfType<PawnsSliding>().SlideNow(target, barrierNum);
        });
    }

    public void DestroySlab()
    {
        Destroy(slabTemp.gameObject);
    }

    IEnumerator WaitForASec()
    {
        yield return new WaitForSeconds(AnimWaitTime);

    }

}
