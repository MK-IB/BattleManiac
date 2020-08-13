using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{

    void FixedUpdate()
    {
        if(transform.position.y <= -1.50f)   
        {
            if(gameObject.tag == "enemyKing" || gameObject.tag == "playerKing")
            {
                FindObjectOfType<WinnerOrLoser>().WinOrLose(gameObject.tag);
            }
            DestroyThis(gameObject);
        }
    }

    private void DestroyThis(GameObject obj)
    {
       
        Destroy(obj);
    }
}
