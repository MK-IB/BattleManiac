using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKing : MonoBehaviour
{

    private Vector3 offset = new Vector3(0f, 1.48f, -1.5f);
    public Transform playerKing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerKing.position + offset;
    }
}
