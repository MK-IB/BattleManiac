using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    private float AnimWaitTime = 1.3f;
    public Animator SlabAnimator;
    public Animator CameraAnimator;
    public GameObject mainUI;
    private float mainUIOffset = 360f;

    public void StartTheGame()
    {
        SlabConnectorAnimation();
        HideMainUI();
    
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
        Destroy(SlabAnimator.gameObject);
    
    }
    public void SlabConnectorAnimation()
    {
        SlabAnimator.SetBool("startSlabAnim", true);
        
        CameraAnimation();
    }

    IEnumerator WaitForASec()
    {
        yield return new WaitForSeconds(AnimWaitTime);
    }

}
