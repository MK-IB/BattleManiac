 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleHandler : MonoBehaviour
{

   [SerializeField] private Transform enemy;
   [SerializeField] private Transform enemyPawn1;
   [SerializeField] private Transform enemyPawn2;

    private GameObject enemyPointer;
    List<GameObject> playersArray;
    List<GameObject> enemyArray;

    private float enemyForcePower;
    private Vector3 playerPosition;
    private Vector3 enemyPosition;  

    private GameObject enemyKing;
    private GameObject playerKing;
    private GameObject attackerEnemy;

    public float minPower = 480f;
    public float maxPower = 550f;
    private float drag = 10f;
    private float damping = 100f;

    private float groundLevel = -0.5f;
    private float playerKingDist = 0.5f;

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
       SpawnCharacters();
   }

    public void SetupPlayers()
    {
        enemyKing = GameObject.FindWithTag("enemyKing").gameObject;
        playerKing = GameObject.FindWithTag("playerKing").gameObject;
        playersArray = new List<GameObject>(GameObject.FindGameObjectsWithTag("playerPawn"));
        playersArray.Add(playerKing);
        enemyArray = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemyPawn"));
        enemyArray.Add(enemyKing);
        
    }

    private void SpawnCharacters()
   {
       Vector3 playerPosition = new Vector3(0.594f, 0.054f, -0.697f);
       Vector3 enemyPosition = new Vector3(0.594f, 0.054f, 0.411f);

       Instantiate(enemy, enemyPosition, Quaternion.identity);
       Instantiate(enemyPawn1, new Vector3(0.081f, 0.0869f, 0.450f), Quaternion.identity);
       Instantiate(enemyPawn2, new Vector3(1.050f, 0.0869f, 0.450f), Quaternion.identity);
   }

    public void EnemyTurn()
    {
        playerPosition = playerKing.transform.position;
        enemyPosition = enemyKing.transform.position;

        //choose enemy attacker
        int enemyIndex = Random.Range(0, enemyArray.Count);
        attackerEnemy = enemyArray[enemyIndex];

        //check if the player King is closer
        float distFromPlayerKing = Vector3.Distance(attackerEnemy.transform.position, playerKing.transform.position);
        if(distFromPlayerKing <= playerKingDist)
        {
            Vector3 dir = playerKing.transform.position - attackerEnemy.transform.position;
            AttackThePlayer(playerKing, dir);
        }
        else
        {
        //choose player to attack and direction of it
        int playerIndex = Random.Range(0, playersArray.Count);
        GameObject toAttack = playersArray[playerIndex];
        Vector3 dir = toAttack.transform.position - attackerEnemy.transform.position;
        AttackThePlayer(toAttack, dir);
        }
        
    }
    //attack
    void  AttackThePlayer(GameObject toAttack, Vector3 dir)
    {
        float power = Random.Range(minPower, maxPower);
        attackerEnemy.GetComponent<Rigidbody>().AddForce(dir * power);
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
