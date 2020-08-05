using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnListManager : MonoBehaviour
{
   public List<GameObject> pawnList;
   public List<Transform> posTile;
   public GameObject pawn;

   private DiamondsCounter diamondsCounter;
   public int numOfPawnsBought = 0;
   private Color matColor;
   
   public Material playersMat;
   public Texture grad1,grad2,grad3,grad4,grad5,grad6,grad7,grad8,grad9;
   private Texture defTexture;
   private int numTile = 1;

    void Start()
    {
        diamondsCounter = FindObjectOfType<DiamondsCounter>();
        SpawnPawns();
        Debug.Log("pawns bought:" + PlayerPrefsController.GetNumOfPawnsBought());
        playersMat.color = PlayerPrefsController.GetMatColor();
    }
   public List<GameObject> GetpawnList()
   {
       return pawnList;
   }

   public void ChangeMatColor(int code)
   {
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
    public void SpawnPawns()
    {
       int pawnNum = PlayerPrefsController.GetNumOfPawnsBought();
       //int posState  = PlayerPrefsController.GetPosTileState();

       if(pawnNum > 0) 
       {
           for(int i = 0; i < pawnNum; i++)
           {
               Instantiate(pawn, posTile[i].position, Quaternion.identity);
           }
       }
    }

   public void AdddPawn(int price)
   {
       
       int tileRemain = (posTile.Count - PlayerPrefsController.GetNumOfPawnsBought()) + 1;
       if(PlayerPrefsController.GetNumOfPawnsBought() == 2)
            numTile = 0;

       if(diamondsCounter.HaveEnoughDiamonds(price) && tileRemain >= 1)
       {
           diamondsCounter.SpendDiamonds(price);
           numOfPawnsBought += 1;
           PlayerPrefsController.SetNumOfPawnsBought(numOfPawnsBought);
           int index = Random.Range(0, posTile.Count);
           if(numTile != 0){
           GameObject newPawn = Instantiate(pawn, posTile[index].position, Quaternion.identity);
           pawnList.Add(newPawn);
           }
           posTile.RemoveAt(index);
       }else Debug.Log("Can't add any Pawn");
       //PlayerPrefsController.NU
       Debug.Log("Num of pawns=" + pawnList.Count);
   }
}
