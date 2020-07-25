using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrundController : MonoBehaviour
{
    public GameObject touchEffect;
    void OnCollisionEnter(Collision collider)
    {
        //if its player or slabs
        if(collider.transform.tag == "slab" || collider.transform.tag == "player")
        {
            GameObject touchVFX = Instantiate(touchEffect, collider.transform.position, Quaternion.identity) as GameObject;
            Debug.Log("Ground collision occured");
            //StartCoroutine(DelayBeforeDestroy());
            //Destroy(touchVFX);
        }
    }

    private IEnumerator DelayBeforeDestroy()
    {
       yield return new WaitForSeconds(0.5f);
       Destroy(touchEffect);
    }
}
