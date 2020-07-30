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

   private int numTile = 1;

    void Start()
    {
        diamondsCounter = FindObjectOfType<DiamondsCounter>();
        SpawnPawns();
        Debug.Log("pawns bought:" + PlayerPrefsController.GetNumOfPawnsBought());
    }
   public List<GameObject> GetpawnList()
   {
       return pawnList;
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
