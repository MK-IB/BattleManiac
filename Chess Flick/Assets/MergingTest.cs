using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergingTest : MonoBehaviour
{

    [SerializeField] private GameObject cube; //prafab instantiation
    private List<GameObject> cubes;
    public List<GameObject> tiles;

    private int tilesCounter;

    private int numOfPawnsBought;
    private int tilesCapacity;

    private bool firstTimePawnAddition = true;
    private bool firstTimeTileAddition = true;
    
    void Start()
    {
        InstantiatePawns();
        DisplayTiles();
        Debug.Log("Tiles counter="+ PlayerPrefsController.GetTilesCounter());
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(LerpPositions());
            //UpdateTileParentPosition();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            //Debug.Log("tiless length:-" + tiles.Count);
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

    /*IEnumerator LerpPositions()
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
    } */

    IEnumerator GoToGround()
    {
       yield return null;
    }

//add tiles
    public void AddTile()
    {
        if(firstTimeTileAddition)
        {
            tilesCounter = 2;
            firstTimeTileAddition = false;
        } else tilesCounter = PlayerPrefsController.GetTilesCounter();
        if(tilesCounter < tiles.Count)
        {
            tiles[tilesCounter].SetActive(true);
            tilesCounter += 1;
            tilesCapacity += 1;
            PlayerPrefsController.SetTilesCapacity(tilesCapacity);
        }else Debug.Log("Tiles out of range");

        PlayerPrefsController.SetTilesCounter(tilesCounter);
    }

    public void AddPawn()
    {
        
        if(firstTimePawnAddition)
        {
            tilesCapacity = 2;
            firstTimePawnAddition = false;
        } else tilesCapacity = PlayerPrefsController.GetTilesCapacity();

        if(tilesCapacity > 0)
        {
            numOfPawnsBought = PlayerPrefsController.GetNumOfPawnsBought();
            Instantiate(cube, tiles[numOfPawnsBought].transform.position, Quaternion.identity);
            tilesCapacity -= 1;
            numOfPawnsBought += 1;
            PlayerPrefsController.SetNumOfPawnsBought(numOfPawnsBought);
            PlayerPrefsController.SetTilesCapacity(tilesCapacity);
        }
    }

    public void InstantiatePawns()
    {
        numOfPawnsBought = PlayerPrefsController.GetNumOfPawnsBought();
        for(int i =0; i < numOfPawnsBought; i++)
        {
            Instantiate(cube, tiles[i].transform.position, Quaternion.identity);
        }
    }

    public void DisplayTiles()
    {
        tilesCounter = PlayerPrefsController.GetTilesCounter();
        for(int i = 0; i < tilesCounter; i++)
        {
            tiles[i].SetActive(true);
        }

    }
}
