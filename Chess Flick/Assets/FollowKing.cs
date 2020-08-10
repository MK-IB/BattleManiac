using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowKing : MonoBehaviour
{

    private Vector3 offset = new Vector3(0f, 1.48f, -1.5f);
    public Transform playerKing;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSceneIndex == 0)
            return;
        else transform.position = playerKing.position + offset;
    }
}
