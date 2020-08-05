using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{

    void FixedUpdate()
    {
        if(transform.position.y <= -1.50f && FindObjectOfType<WinnerOrLoser>())   
        FindObjectOfType<WinnerOrLoser>().WinOrLose(gameObject.tag);
    }
}
