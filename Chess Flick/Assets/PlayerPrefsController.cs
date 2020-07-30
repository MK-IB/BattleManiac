 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string SAVED_LEVEL_INDEX = "SavedSceneNumber";
    const string NUM_OF_BOUGHT_PAWNS= "Pawns bought";
    const string NUM_OF_DIAMONDS= "Num of diamonds";
    const string POS_TILE_NULL = "PosTile State";

    public static void SetPosTileState(int state)
    {   
        PlayerPrefs.SetInt(POS_TILE_NULL, state);
    }

    public static int GetPosTileState()
    {   
        return PlayerPrefs.GetInt(POS_TILE_NULL);
    }

    public static int GetSavedLevel()
    {
        return PlayerPrefs.GetInt(SAVED_LEVEL_INDEX);
    }

    public static void SetDiamonds(int diamonds)
    {
        PlayerPrefs.SetInt(NUM_OF_DIAMONDS, diamonds);
    }
    
    public static int GetDiamonds()
    {
        return PlayerPrefs.GetInt(NUM_OF_DIAMONDS);
    }
    public static void SetNumOfPawnsBought(int num)
    {
        PlayerPrefs.SetInt(NUM_OF_BOUGHT_PAWNS, num);
    }
    
    public static int GetNumOfPawnsBought()
    {
        return PlayerPrefs.GetInt(NUM_OF_BOUGHT_PAWNS);
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
