 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BattleHandler : MonoBehaviour
{


    private GameObject enemyPointer;
    List<GameObject> playersArray;
    public List<GameObject> enemies;
    private List<GameObject> enemyArray;
    
    private List<GameObject> tiles;
    public List<GameObject> level1Tiles;

    private float enemyForcePower;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;  

    private GameObject enemyKing;
    private GameObject playerKing;
    private GameObject attackerEnemy;
    private GameObject toAttack;

    public float minPower ;
    public float maxPower;
    private float drag = 10f;
    private float damping = 100f;

    private float groundLevel = -0.5f;
    private float playerKingDist = 0.5f;

    public float zOffset;

    private void Awake()
    {
        enemyPointer=GameObject.Find("enemyPointer");
         //enemyPointer.GetComponent<MeshRenderer>().enabled = false;
    }

    void Start()
    {
        enemyArray = new List<GameObject>();
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            tiles = level1Tiles;
        }
    }
    void Update()
    {
        
    }
   public void InitializeSpawning()
   {
       SetupPlayers();
   }

    public void SetupPlayers()
    {
        playersArray = new List<GameObject>(GameObject.FindGameObjectsWithTag("playerPawn"));
        playersArray.Add(GameObject.FindGameObjectWithTag("playerKing"));
        //enemyArray = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemyPawn"));
        //enemyArray.Add(GameObject.FindGameObjectWithTag("enemyKing"));
        SpawnEnemies();
        
    }

    public void SetTiles(List<GameObject> tilePos)
    {
        tiles = tilePos;
    }

    private void SpawnEnemies()
   {
        Debug.Log("Enemy array length:" + enemies.Count);
        Debug.Log("Tiles lenght:" + tiles.Count);
        for(int i = 0; i < enemies.Count; i++)
            {
                Vector3 pos = new Vector3(tiles[i].transform.position.x,
                                            tiles[i].transform.position.y,
                                            tiles[i].transform.position.z + zOffset);
                GameObject temp = Instantiate(enemies[i], pos, Quaternion.identity);
                enemyArray.Add(temp);
            }
   }

    public void EnemyTurn()
    {
        if(transform.eulerAngles.x > 45 || transform.eulerAngles.x < -45 ||
            transform.eulerAngles.z > 45 || transform.eulerAngles.z < -45)
                {transform.eulerAngles = Vector3.zero;}
                
        //INITIALIZE THE PLAYERS AGAIN TO AVOID NULL EXCEPTIONS
        if(GameObject.FindGameObjectWithTag("playerPawn"))
            playersArray = new List<GameObject>(GameObject.FindGameObjectsWithTag("playerPawn"));
        else {
            playersArray = new List<GameObject>();
            playersArray.Add(GameObject.FindGameObjectWithTag("playerKing"));
        }
        playersArray.Add(GameObject.FindGameObjectWithTag("playerKing"));
        enemyKing = GameObject.FindGameObjectWithTag("enemyKing");
        Debug.Log("Its enemy turn");
        enemyPosition = enemyKing.transform.position;

        //choose enemy attacker randomly
        int enemyIndex = Random.Range(0, enemyArray.Count);
        attackerEnemy = enemyArray[enemyIndex];
        //check if the player King is closer
        /*float distFromPlayerKing = Vector3.Distance(attackerEnemy.transform.position, playerKing.transform.position);
        if(distFromPlayerKing <= playerKingDist)
        {
            Vector3 dir = playerKing.transform.position - attackerEnemy.transform.position;
            AttackThePlayer(playerKing, dir);
        }
        else
        { */
        //choose player to attack and direction of it
        int playerIndex = Random.Range(0, playersArray.Count);
        toAttack = playersArray[playerIndex];
        Vector3 dir = toAttack.transform.position - attackerEnemy.transform.position;
        AttackThePlayer(toAttack, dir);
        //}
        
    }
    //attack
    void  AttackThePlayer(GameObject toAttack, Vector3 dir)
    {
        float power = Random.Range(minPower, maxPower);
        attackerEnemy.GetComponent<Rigidbody>().AddForce(dir * power);
        Debug.Log("Attack script called");
    }
    

    public void DestroyTheEnemies()
    {
        if(enemyArray == null) return;
        foreach(GameObject obj in enemyArray)
        {
            Destroy(obj);
        }
    }
   //When Touching UI
    /*private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        Debug.Log("Res"+ results.Count);
        return results.Count > 0;
    } */
}
