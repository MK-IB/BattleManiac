using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnsSliding : MonoBehaviour
{
    private List<GameObject> pawns;
    public Transform target1;
    public List<GameObject> target2;
    public Transform moveRef;
    
    public float speed;

    public float diff;
    private int j; 
    //public float zOffset = 5.17f;
    //actual -5.592

    private Vector3 cubePos;
    void Start()
    {
       pawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("playerPawn"));
       pawns.Add(GameObject.FindGameObjectWithTag("playerKing"));
       j = pawns.Count - 1;
        
    }
    public List<GameObject> GetPawnList()
    {
        return pawns;
    }
    void Update()
    {

        
    }

    //FLOW CAME FROM THE SLAB ANIM EVENT
    public void SlideNow()
    {
        StartCoroutine(LerpToTarget2());
    }
    //lerping to target 1
     IEnumerator LerpToTarget1()
    {   
        //moveRef.GetComponent<SpriteRenderer>().enabled = false;
        for(int i = 0; i < pawns.Count; i++)
        {
            while((target1.transform.position.z - pawns[i].transform.position.z) > diff)
            {
                pawns[i].transform.position = Vector3.MoveTowards(pawns[i].transform.position, target1.transform.position, Time.deltaTime * speed);
                yield return null;
            }
         StartCoroutine(LerpToTarget2());   
        }
    }

    
    IEnumerator LerpToTarget2()
    {
           for(int i = 0; i < pawns.Count; i++)
            {
            while((target2[j].transform.position.z - pawns[i].transform.position.z) > diff)
            {
                pawns[i].transform.position = Vector3.MoveTowards(pawns[i].transform.position, target2[j].transform.position, Time.deltaTime * speed);
                yield return null;
            }
            j--;
            }
                FindObjectOfType<FollowKing>().enabled = false;
            FindObjectOfType<AnimationController>().DestroyTheAnimatedObjects();
            GameObject.FindObjectOfType<GrundController>().ShowUpBarrier();
        
    }
}
