using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTestAnimation : MonoBehaviour
{
    //public List<GameObject> objects;
    private List<GameObject> cubes;
    public Transform obj;
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
        cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 newPos = new Vector3(moveRef.position.x, moveRef.position.y, moveRef.position.z + zOffset);
        moveRef.position = newPos;
            StartCoroutine(LerpToTarget2());
            //Debug.Log("Lerp should start now");
        }
        
    }


    //lerping to target 1
     IEnumerator LerpToTarget1()
    {   
        cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
        //cubes.Add(GameObject.FindGameObjectWithTag("sphere"));
        //  foreach(GameObject obj in cubes)
            //obj.GetComponent<BoxCollider>().isTrigger = true;
        
        for(int i = 0; i < cubes.Count; i++)
        {
            while((target1.transform.position.z - cubes[i].transform.position.z) > diff)
            {
                cubes[i].transform.position = Vector3.MoveTowards(cubes[i].transform.position, target1.transform.position, Time.deltaTime * speed);
                yield return null;
            }
            diff += 1f;
         StartCoroutine(LerpToTarget3());   
        }
    }

    IEnumerator LerpToTarget3()
    {
        diff = 0f;
        for(int i = 0; i < cubes.Count; i++)
        {
            while((target3.transform.position.z - cubes[i].transform.position.z) > diff)
            {
                cubes[i].transform.position = Vector3.MoveTowards(cubes[i].transform.position, target3.transform.position, Time.deltaTime * speed);
                yield return null;
            }
            StopCoroutine(LerpToTarget1());
         StartCoroutine(LerpToTarget2());   
        }

    }
    IEnumerator LerpToTarget2()
    {

        //cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
        //cubes.Add(GameObject.FindGameObjectWithTag("sphere"));
        //speed = 1f;
        int j = cubes.Count;
           for(int i = 0; i < cubes.Count; i++)
            {
            while((target2[j].transform.position.z - cubes[i].transform.position.z) > diff)
            {
                cubes[i].transform.position = Vector3.Lerp(cubes[i].transform.position, target2[j].transform.position, Time.deltaTime * speed);
                yield return null;
            }
            j --;
            }
            StopCoroutine(LerpToTarget3());
    }
}
