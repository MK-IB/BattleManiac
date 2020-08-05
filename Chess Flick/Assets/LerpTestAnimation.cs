using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTestAnimation : MonoBehaviour
{
    //public List<GameObject> objects;
    public List<Transform> objects;
    public Transform target1;
    public Transform target2;
    public float speed;

    private float diff = 1f;

    private Vector3 cubePos;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LerpPosition());
            Debug.Log("Lerp should start now");
        }
        
    }

    IEnumerator LerpPosition()
    {   
        foreach(Transform obj in objects)
        {
            while((target1.position.x - obj.transform.position.x) > diff)
             {
                 obj.transform.position = Vector3.Lerp(obj.transform.position, target1.position, Time.deltaTime * speed );
                 yield return null;
             }
             diff += 1f;  
        } 
        StartCoroutine(LerpPosition2());
        
    }

    IEnumerator LerpPosition2()
    {   
        diff = 0.5f;
        foreach(Transform obj in objects)
        {
            while((target2.position.x - obj.transform.position.x) > diff)
             {
                 obj.transform.position = Vector3.Lerp(obj.transform.position, target2.position, Time.deltaTime * speed );
                 yield return null;
             }
             diff += 1f;  

            }           
    } 
}
