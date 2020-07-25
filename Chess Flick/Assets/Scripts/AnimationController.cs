using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private float AnimWaitTime = 1.3f;
    public Animator SlabAnimator;
    public Animator Pawn1Animator;
    public Animator Pawn2Animator;
    public Animator KingAnimator;
    public Animator CameraAnimator;
    public Animator BattleButtonAnimator;
    public Animator SkinChangeButtonAnimator;
    public Animator ObjectChangeButtonAnimator;

    public void StartTheGame()
    {
        SlabConnectorAnimation();
        BattleButtonAnimation();
    }

    public void BattleButtonAnimation()
    {
        BattleButtonAnimator.SetBool("startButtonAnimation", true);
        SkinChangeButtonAnimator.SetBool("skinChangeButtonAnimation", true);
        ObjectChangeButtonAnimator.SetBool("extraObjAnimation", true);

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

    public void KnightAnimation()
    {
        
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
