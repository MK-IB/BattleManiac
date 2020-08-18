using UnityEngine;
using UnityEditor;

public class PlayerPrefsController : MonoBehaviour
{
    const string SAVED_LEVEL_INDEX = "SavedSceneNumber";
    const string NUM_OF_BOUGHT_PAWNS= "Pawns bought";
    const string NUM_OF_DIAMONDS= "Num of diamonds";
    const string POS_TILE_NULL = "PosTile State";

    const string MAT_COLOR = "Color code";
    const string TILES_COUNTER = "Tiles 2 counter";
    const string TILES_CAPACITY = "Tiles capacity";
    
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

    public static void SetSavedLevel(int index)
    {
        PlayerPrefs.SetInt(SAVED_LEVEL_INDEX, index);
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

    public static void ResetAll()
    {
            PlayerPrefs.DeleteAll();
    }

    public static void SetMatColor(Color color)
    {
        PlayerPrefsX.SetColor(MAT_COLOR, color);
    }

    public static Color GetMatColor()
    {
        return PlayerPrefsX.GetColor(MAT_COLOR);
    }
//testing purposes
    public static void SetTilesCounter(int num)
    {
        PlayerPrefs.SetInt(TILES_COUNTER, num);
    }

    public static int GetTilesCounter()
    {
        return PlayerPrefs.GetInt(TILES_COUNTER);
    }

    //set / get  tiles capacity
    public static void SetTilesCapacity(int num)
    {
        PlayerPrefs.SetInt(TILES_CAPACITY, num);
    }

    public static int GetTilesCapacity()
    {
        return PlayerPrefs.GetInt(TILES_CAPACITY);
    }
}
