using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokePawnsAnim : MonoBehaviour
{
   public void StartPawnsSliding()
   {
       FindObjectOfType<PawnsSliding>().SlideNow();
   }
}
