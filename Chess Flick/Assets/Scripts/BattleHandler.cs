﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private Transform enemy;
   [SerializeField] private Transform playerPawn1;
   [SerializeField] private Transform playerPawn2;
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

    public float minPower = 480f;
    public float maxPower = 550f;
    private float drag = 10f;
    private float damping = 100f;

    private float groundLevel = -0.5f;

    private void Awake()
    {
        enemyPointer=GameObject.Find("enemyPointer");
         //enemyPointer.GetComponent<MeshRenderer>().enabled = false;
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

       Instantiate(player, playerPosition, Quaternion.identity);
       Instantiate(enemy, enemyPosition, Quaternion.identity);
       Instantiate(playerPawn1, new Vector3(0.081f, 0.0869f, -0.6112f), Quaternion.identity);
       Instantiate(playerPawn1, new Vector3(1.050f, 0.0869f, -0.6112f), Quaternion.identity);
       Instantiate(enemyPawn1, new Vector3(0.081f, 0.0869f, 0.450f), Quaternion.identity);
       Instantiate(enemyPawn2, new Vector3(1.050f, 0.0869f, 0.450f), Quaternion.identity);
   }

    public void EnemyTurn()
    {
        playerPosition = playerKing.transform.position;
        enemyPosition = enemyKing.transform.position;

        //choose enemy attacker
        int enemyIndex = Random.Range(0, enemyArray.Count);
        GameObject attackerEnemy = enemyArray[enemyIndex];

        //get direction of player
        int playerIndex = Random.Range(0, playersArray.Count);
        GameObject toAttack = playersArray[playerIndex];
        Vector3 dir = toAttack.transform.position - attackerEnemy.transform.position;

        //enable the pointer
         //enemyPointer.GetComponent<MeshRenderer>().enabled = true;
         //enemyPointer.transform.Rotate(dir);
        //attack
        float power = Random.Range(minPower, maxPower);
        attackerEnemy.GetComponent<Rigidbody>().AddForce(dir * power);
    }

    
   
}
