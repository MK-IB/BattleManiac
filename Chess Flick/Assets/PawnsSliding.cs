using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnsSliding : MonoBehaviour
{
    private List<GameObject> pawns;
    public Transform target1;
    public Transform moveRef;
    
    public float speed;

    public float diff;
    private int j; 
    //public float zOffset = 5.17f;
    //actual -5.592

    private Vector3 cubePos;
    void Start()
    {
       
        
    }
    public List<GameObject> GetPawnList()
    {
        return pawns;
    }
    void Update()
    {

        
    }

    //FLOW CAME FROM THE SLAB ANIM EVENT
   public void SlideNow(List<GameObject> target, int barrierNum)
    {
        pawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("playerPawn"));
       pawns.Add(GameObject.FindGameObjectWithTag("playerKing"));
        j = pawns.Count-1;
        FindObjectOfType<FollowKing>().enabled = true;
        StopCoroutine("SlideToTarget");
        StartCoroutine(SlideToTarget(pawns, target, barrierNum));
    } 

        //dont call this after any enum, will cause unusual faster execution
    public IEnumerator SlideToTarget(List<GameObject> pawns, List<GameObject> target, int barrierNum)
    {  
           for(int i = 0; i < pawns.Count; i++)
            {
            while((target[j].transform.position.z - pawns[i].transform.position.z) > diff)
            {
                pawns[i].transform.position = Vector3.MoveTowards(pawns[i].transform.position, target[j].transform.position, Time.deltaTime * speed);
                yield return null;
            }
            j--;
            }
            FindObjectOfType<FollowKing>().enabled = false;
            FindObjectOfType<BattleHandler>().SetTiles(target);
            GameObject.FindObjectOfType<GrundController>().ShowUpBarrier(barrierNum);
        
    }
}
