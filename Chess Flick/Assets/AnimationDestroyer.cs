using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
   public void DestroyAnimatoinObject()
   {
       FindObjectOfType<AnimationController>().DestroyTheAnimatedObjects();
       FindObjectOfType<BattleHandler>().InitializeSpawning();
   }
}
