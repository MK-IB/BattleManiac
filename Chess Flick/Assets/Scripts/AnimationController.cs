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
    
    public Animator CameraAnimator;
    public GameObject mainUI;
    private float mainUIOffset = 360f;

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

    private void HideMainUI()
    {
       mainUI.SetActive(false);
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
        Vector3 scaleTo = new Vector3(1.2f, 0.11f, 3.98f);
        slab.DOScale(scaleTo, 1.5f).OnComplete(()=> {
            FindObjectOfType<PawnsSliding>().SlideNow(target, barrierNum);
        });
        //SlabShrinkAnimation(slab);
    }

    public void SlabShrinkAnimation(Transform slab)
    {
        slab1.DOScale(Vector3.zero, 1.5f);
    }

    IEnumerator WaitForASec()
    {
        yield return new WaitForSeconds(AnimWaitTime);

    }

}
