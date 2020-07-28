using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
   public void DestroyAnimatoinObject()
   {
       //disable the animator component of camera
       GetComponent<Animator>().enabled =  false;
       FindObjectOfType<AnimationController>().DestroyTheAnimatedObjects();
       FindObjectOfType<BattleHandler>().InitializeSpawning();
   }
}
