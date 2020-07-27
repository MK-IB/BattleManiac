using DG.Tweening;
using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    private float AnimWaitTime = 1.3f;
    public Animator SlabAnimator;
    public Animator Pawn1Animator;
    public Animator Pawn2Animator;
    public Animator KingAnimator;
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
    public  void Pawn1Animation()
    {
        Pawn1Animator.SetBool("startPawn1Animation", true);
        Pawn2Animation();

    }

    public  void Pawn2Animation()
    {
        Pawn2Animator.SetBool("startPawn2Animation", true);
        KingAnimation();

    }

    public void KingAnimation()
    {
        KingAnimator.SetBool("startKingAnimation", true);
        CameraAnimation();
    }

    public void CameraAnimation()
    {
        CameraAnimator.SetBool("cameraAnimation", true);

    }

    public void DestroyTheAnimatedObjects()
    {
        Destroy(SlabAnimator.gameObject);
        Destroy(Pawn1Animator.gameObject);
        Destroy(Pawn2Animator.gameObject);
        Destroy(KingAnimator.gameObject);
    }
    public void SlabConnectorAnimation()
    {
        SlabAnimator.SetBool("startSlabAnim", true);
        StartCoroutine(WaitForASec());
        Pawn1Animation();
    }

    IEnumerator WaitForASec()
    {
        yield return new WaitForSeconds(AnimWaitTime);
    }

}
