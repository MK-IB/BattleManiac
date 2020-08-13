using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "ground" || collider.gameObject.tag == "slab")
            return;
        else 
        {
            Handheld.Vibrate();   
        }
    }
}
