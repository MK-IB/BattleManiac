using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnsSliding : MonoBehaviour
{
    private List<GameObject> pawns;
    public Transform target1;
    public Transform target2;
    public List<GameObject> target3;
    public Transform moveRef;
    
    public float speed;

    public float diff;
    private float zOffset = 5.09f;

    private Vector3 cubePos;
    void Start()
    {
        //target3 = new List<GameObject>(GameObject.FindGameObjectsWithTag("tile"));
        
    }

    void Update()
    {

        
    }

    //FLOW CAME FROM THE SLAB ANIM EVENT
    public void SlideNow()
    {
        pawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("playerPawn"));
        pawns.Add(GameObject.FindGameObjectWithTag("playerKing"));
        StartCoroutine(LerpToTarget1());
    }
    //lerping to target 1
     IEnumerator LerpToTarget1()
    {   

        Vector3 newPos = new Vector3(moveRef.position.x, moveRef.position.y, moveRef.position.z + zOffset);
        moveRef.position = newPos;
        //moveRef.GetComponent<SpriteRenderer>().enabled = false;
        for(int i = 0; i < pawns.Count; i++)
        {
            while((target1.transform.position.z - pawns[i].transform.position.z) > diff)
            {
                pawns[i].transform.position = Vector3.Lerp(pawns[i].transform.position, target1.transform.position, Time.deltaTime * speed);
                yield return null;
            }
         StartCoroutine(LerpToTarget2());   
        }
    }

    IEnumerator LerpToTarget2()
    {
        for(int i = 0; i < pawns.Count; i++)
        {
            while((target2.transform.position.z - pawns[i].transform.position.z) > diff)
            {
                pawns[i].transform.position = Vector3.Lerp(pawns[i].transform.position, target2.transform.position, Time.deltaTime * speed);
                yield return null;
            }
         StartCoroutine(LerpToTarget3());   
        }

    }
    IEnumerator LerpToTarget3()
    {
        //cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
        //cubes.Add(GameObject.FindGameObjectWithTag("sphere"));
           for(int i = 0; i < pawns.Count; i++)
            {
            while((target3[i].transform.position.z - pawns[i].transform.position.z) > 0)
            {
                pawns[i].transform.position = Vector3.Lerp(pawns[i].transform.position, target3[i].transform.position, Time.deltaTime * speed);
                yield return null;
            }
            }
    }
}
