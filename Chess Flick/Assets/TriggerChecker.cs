using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
   void OnTriggerEnter(Collider collider)
   {
       if(collider.tag == "finishLine")
       {
           FindObjectOfType<RoundsController>().finishLineTouched = true;
       }
   }
}
