using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float speed = 1f;
    float minXRot = 42.5f;
    float maxXRot = 60.0f;
    private Quaternion camRot;

    void Start()
    {
        camRot = transform.localRotation;
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
        camRot.x += Input.GetAxis("Mouse Y") * speed;
        camRot.y += Input.GetAxis("Mouse X") * speed;

        transform.localRotation = Quaternion.Euler(camRot.x, camRot.y, 0);
        }
    }
}
