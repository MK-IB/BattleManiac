using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
   void OnTriggerEnter(Collider collider)
   {
       if(collider.tag == "finishLine")
       {
           FindObjectOfType<RoundsController>().ShowRoundIndicator();
           FindObjectOfType<RoundsController>().finishLineTouched = true;
       }
       else if(collider.tag == "round 1")
       {
           FindObjectOfType<RoundsController>().SetRoundsCompleted(1);
           FindObjectOfType<RoundsController>().ShowRoundIndicator();
       }
       else if(collider.tag == "round 2")
       {
           FindObjectOfType<RoundsController>().SetRoundsCompleted(2);
           FindObjectOfType<RoundsController>().ShowRoundIndicator();
       }
       else if(collider.tag == "round 3")
       {
           FindObjectOfType<RoundsController>().SetRoundsCompleted(3);
           FindObjectOfType<RoundsController>().ShowRoundIndicator();
       }
   }
}
