using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergingTest : MonoBehaviour
{

    [SerializeField] private GameObject cube; //prafab instantiation
    private List<GameObject> cubes;
    public List<GameObject> tiles1;
    public List<GameObject> tiles2;
    public Transform target1;
    private float diff = 0.5f;
    private float speed = 2f;

    private int tile2Counter = 0;

    private int numOfCubesBought;
    private int tile1Capacity;
    
    void Start()
    {
        //cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("cube"));
        

    }

    void Update()
    {
        Debug.Log("Tiles 1 check" + tiles2[1].transform.position);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LerpPositions());
            //UpdateTileParentPosition();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("tiless 2 length:-" + tiles2.Count);
            AddTile();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            AddPawn();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            InstantiatePawns();
        }
        //reset the playerprefs
        if(Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefsController.ResetAll();
        }
    }

    IEnumerator LerpPositions()
    {
        
        foreach(GameObject obj in cubes)
        {
            while((target1.position.x - obj.transform.position.x) > diff)
             {
                 obj.transform.position = Vector3.Lerp(obj.transform.position, target1.position, Time.deltaTime * speed );
                 yield return null;
             }
             diff += 1f;  
        } 
        
        StartCoroutine(GoToGround());
    }

    IEnumerator GoToGround()
    {
       yield return null;
    }

//add tiles
    public void AddTile()
    {
        if(tile2Counter < tiles2.Count)
        {
            tiles2[tile2Counter].SetActive(true);
            tile2Counter += 1;
        }else Debug.Log("Tiles out of range");

        PlayerPrefsController.SetTiles2Counter(tile2Counter);
    }

    public void AddPawn()
    {
        numOfCubesBought = PlayerPrefsController.GetNumOfPawnsBought();
        tile1Capacity = 2 - numOfCubesBought;
        if(numOfCubesBought <= tile1Capacity)
        {
            Instantiate(cube, tiles1[numOfCubesBought].transform.position, Quaternion.identity);
            numOfCubesBought += 1;
            PlayerPrefsController.SetNumOfPawnsBought(numOfCubesBought);

        } else Debug.Log("Have to add on tiles2");

    }

    public void InstantiatePawns()
    {
    
    }
}
