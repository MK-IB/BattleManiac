using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnListManager : MonoBehaviour
{
   public List<GameObject> pawnList;
   public List<Transform> posTile;
   public GameObject pawn;
   public List<GameObject> GetpawnList()
   {
       return pawnList;
   }

   public void AdddPawnToList()
   {
       int index = Random.Range(0, posTile.Count);
       GameObject newPawn = Instantiate(pawn, posTile[index].position, Quaternion.identity);
       if(posTile != null)
            pawnList.Add(newPawn);
       posTile.RemoveAt(index);

       //PlayerPrefsController.NU
   }
}
