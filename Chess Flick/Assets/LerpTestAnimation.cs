using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTestAnimation : MonoBehaviour
{
    //public List<GameObject> objects;
    private List<GameObject> cubes;
    public Transform target1;
    public Transform target3;
    public List<Transform> target2;
    public Transform moveRef;
    
    public float speed;

    private float diff = 1f;
    private float zOffset = 35f;

    private Vector3 cubePos;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LerpToTarget1());
            Debug.Log("Lerp should start now");
        }
        
    }

    //lerping to target 1
     IEnumerator LerpToTarget1()
    {   
        cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
        cubes.Add(GameObject.FindGameObjectWithTag("sphere"));
        Vector3 newPos = new Vector3(moveRef.position.x, moveRef.position.y, moveRef.position.z + zOffset);
        moveRef.position = newPos;
        for(int i = 0; i < cubes.Count; i++)
        {
            while((target1.transform.position.z - cubes[i].transform.position.z) > diff)
            {
                cubes[i].transform.position = Vector3.Lerp(cubes[i].transform.position, target1.transform.position, Time.deltaTime * speed);
                yield return null;
            }
         StartCoroutine(LerpToTarget3());   
        }
    }

    IEnumerator LerpToTarget3()
    {
        for(int i = 0; i < cubes.Count; i++)
        {
            while((target3.transform.position.z - cubes[i].transform.position.z) > diff)
            {
                cubes[i].transform.position = Vector3.Lerp(cubes[i].transform.position, target3.transform.position, Time.deltaTime * speed);
                yield return null;
            }
         StartCoroutine(LerpToTarget2());   
        }

    }
    IEnumerator LerpToTarget2()
    {
        //cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
        //cubes.Add(GameObject.FindGameObjectWithTag("sphere"));
           for(int i = 0; i < cubes.Count; i++)
            {
            while((target2[i].transform.position.z - cubes[i].transform.position.z) > diff)
            {
                cubes[i].transform.position = Vector3.Lerp(cubes[i].transform.position, target2[i].transform.position, Time.deltaTime * speed);
                yield return null;
            }
            }
    }
}
