using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenTest : MonoBehaviour
{
    private List<GameObject> cubes;
    public Transform target1;
    public List<GameObject> target2;
    
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            Tween1(target1, target2);
        }
        
    }

    public void Tween1(Transform target1, List<GameObject> target2)
    {
        for(int i=0; i<cubes.Count; i++)
        {
            float x = target1.transform.position.x;
            float y = cubes[i].transform.position.y;
            float z = target1.transform.position.z;
            cubes[i].transform.DOMove(new Vector3(x,y,z), 1f).OnComplete(()=>
            {
                Tween2(target2);
            });
            StartCoroutine(Wait());
        }
    }
IEnumerator Wait()
{
    yield return new WaitForSeconds(0.3f);
}
    public void Tween2(List<GameObject> target2)
    {
        for(int i=0; i < cubes.Count; i++)
        {
            float x = target2[i].transform.position.x;
            float y = cubes[i].transform.position.y;
            float z = target2[i].transform.position.z;
            cubes[i].transform.DOMove(new Vector3(x,y,z), 1f);
        }
    }
}
