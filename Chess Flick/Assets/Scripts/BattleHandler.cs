 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleHandler : MonoBehaviour
{


    private GameObject enemyPointer;
    List<GameObject> playersArray;
    public List<GameObject> enemyArray;
    
    private List<GameObject> tiles;

    private float enemyForcePower;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;  

    private GameObject enemyKing;
    private GameObject playerKing;
    private GameObject attackerEnemy;

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

    void Update()
    {
        
    }
   public void InitializeSpawning()
   {
       SpawnEnemies();
   }

    public void SetupPlayers()
    {
        
        Debug.Log("Setup player is called");
        enemyKing = GameObject.FindWithTag("enemyKing").gameObject;
        playerKing = GameObject.FindWithTag("playerKing").gameObject;
        
    }

    private void SpawnEnemies()
   {
       playersArray = FindObjectOfType<PawnListManager>().GetPawns();
        Debug.Log("Enemy array length:" + enemyArray.Count);
        for(int i = 0; i < enemyArray.Count; i++)
            {
                Vector3 pos = new Vector3(playersArray[i].transform.position.x,
                                            playersArray[i].transform.position.y,
                                            playersArray[i].transform.position.z + zOffset);
                Instantiate(enemyArray[i], pos, Quaternion.identity);
            }
            SetupPlayers();
   }

    public void EnemyTurn()
    {
        Debug.Log("Its enemy turn");
        enemyPosition = enemyKing.transform.position;
        playerPosition = playerKing.transform.position;

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
        GameObject toAttack = playersArray[playerIndex];
        Vector3 dir = toAttack.transform.position - attackerEnemy.transform.position;
        AttackThePlayer(toAttack, dir);
        //}
        
    }
    //attack
    void  AttackThePlayer(GameObject toAttack, Vector3 dir)
    {
        float power = Random.Range(minPower, maxPower);
        attackerEnemy.GetComponent<Rigidbody>().AddForce(Vector3.up * power);
        Debug.Log("Attack script called");
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
