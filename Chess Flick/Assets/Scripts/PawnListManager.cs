using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PawnListManager : MonoBehaviour
{
    private List<GameObject> pawns;
    public List<GameObject> tiles;
    public GameObject pawn;

   private DiamondsCounter diamondsCounter;
   private int numOfPawnsBought;
   private int tilesCapacity;
   private int tilesCounter;

   private bool firstTimePawnAddition = true;
    private bool firstTimeTileAddition = true;
   private Color matColor;
   
   public Material playersMat;
   public Texture grad1,grad2,grad3,grad4,grad5,grad6,grad7,grad8,grad9;
   private Texture defTexture;

    private int basicColorBtnNum;
    private List<GameObject> basicColorButtons;
   

    void Start()
    {
        basicColorButtons = new List<GameObject>();
        pawns = new List<GameObject>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current level is" + currentSceneIndex);
        if(currentSceneIndex == 0)
            playersMat.color = new Color(0.47f, 0.58f, 1f);
        else playersMat.color = PlayerPrefsController.GetMatColor();
        diamondsCounter = FindObjectOfType<DiamondsCounter>();
        InstantiatePawns();
        DisplayTiles();
        Debug.Log("Pawns bought:" + PlayerPrefsController.GetNumOfPawnsBought());
        
    }

    
   public void ChangeMatColor(int code)
   {
       basicColorBtnNum = code;
       switch(code)
       {
           case 1:
           matColor = new Color(1f, 0.07f, 0.66f);
           break;

           case 2:
           matColor = new Color(0.27f, 0.98f, 0.44f);
           break;

           case 3:
           matColor = new Color(0.13f, 0.94f, 1f);
           break;

           case 4:
           matColor = new Color(1f, 0.78f, 0.33f);
           break;

           case 5:
           matColor = new Color(0.92f, 0.34f, 0.91f);
           break;

           case 6:
           matColor = new Color(0.74f, 0.80f, 1f);
           break;

           case 7:
           matColor = new Color(0.97f, 0.40f, 0.40f);
           break;

           case 8:
           matColor = new Color(0.47f, 0.58f, 1f);
           break;

           case 9:
           matColor = new Color(0.99f, 0.98f, 0.10f);
           break;

       }
       
       playersMat.color = matColor;
       playersMat.mainTexture = null;
       PlayerPrefsController.SetMatColor(matColor);
       ShowSelectedBasicColorButton();
   }

    //show selected basic color button 
    public void ShowSelectedBasicColorButton()
    {
        basicColorButtons = new List<GameObject>(GameObject.FindGameObjectsWithTag("basicColorButton"));
        for(int i = 0; i < basicColorButtons.Count; i++)
        {
                basicColorButtons[i].GetComponent<Image>().color = Color.grey;
        }
        for(int i = 0; i < basicColorButtons.Count; i++)
        {
            int serial = i + 1;
            if(serial == basicColorBtnNum)
            {
                Debug.Log("Button selected" + i);
                basicColorButtons[i].GetComponent<Image>().color = Color.white;
            }
        }

    }
    //Change the texture
   public void ChangeTexture(int code)
   {
       switch(code)
       {
           case 10:
           defTexture = grad1;
           break;

           case 11:
           defTexture = grad2;
           break;

           case 12:
           defTexture = grad3;
           break;

           case 13:
           defTexture = grad4;
           break;

           case 14:
           defTexture = grad5;
           break;

           case 15:
           defTexture = grad6;
           break;

           case 16:
           defTexture = grad7;
           break;

           case 17:
           defTexture = grad8;
           break;

           case 18:
           defTexture = grad9;
           break;
   }

   playersMat.mainTexture = defTexture;
   playersMat.color = Color.white;
}
    public void InstantiatePawns()
    {
        numOfPawnsBought = PlayerPrefsController.GetNumOfPawnsBought();
        //numOfPawnsBought = 0;
        for(int i =0; i < numOfPawnsBought; i++)
        {
            pawns[i] = Instantiate(pawn, tiles[i].transform.position, Quaternion.identity);
        }
    }

    //get the pawns
    public List<GameObject> GetPawns()
    {
        return pawns;
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
            pawns.Add(Instantiate(pawn, tiles[numOfPawnsBought].transform.position, Quaternion.identity));
            tilesCapacity -= 1;
            numOfPawnsBought += 1;
            PlayerPrefsController.SetNumOfPawnsBought(numOfPawnsBought);
            PlayerPrefsController.SetTilesCapacity(tilesCapacity);
        }
    }
   

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
    //SHOW ALL THE TILES BOUGHT
    public void DisplayTiles()
    {
        tilesCounter = PlayerPrefsController.GetTilesCounter();
        for(int i = 0; i < tilesCounter; i++)
        {
            tiles[i].SetActive(true);
        }

    }
}
