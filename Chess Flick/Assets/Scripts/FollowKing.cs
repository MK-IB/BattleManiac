using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowKing : MonoBehaviour
{

    private Vector3 offset = new Vector3(0f, 1.8f, -1.7f);
    private float offsetZ = -1.7f;
    public Transform playerKing;
    int currentSceneIndex;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerKing.position.z + offsetZ);
    }
}
