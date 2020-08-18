using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
   private Touch initTouch = new Touch();
   private float rotX = 0f;
   private float rotY = 0f;
   private Vector3 origRot;

   public float rotSpeed = 0.5f;
   private float dir = -1;

   void Start()
   {
       origRot = transform.eulerAngles;
       rotX = origRot.x;
       rotY = origRot.y;
   }

   void FixedUpdate()
   {
       foreach(Touch touch in Input.touches)
       {
           if(touch.phase == TouchPhase.Began)
           {
               initTouch = touch;
           }
           else if(touch.phase == TouchPhase.Moved)
           {
               float deltaX = initTouch.position.x - touch.position.x;
               float deltaY = initTouch.position.y - touch.position.y;
               rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
               rotY -= deltaX * Time.deltaTime * rotSpeed * dir;
               rotX = Mathf.Clamp(rotX, 40f, 60f);
               //rotY = Mathf.Clamp(rotY, 0f, 180f);
               transform.eulerAngles = new Vector3(rotX, 0, 0f);
           }
           else if(touch.phase == TouchPhase.Ended)
           {
               initTouch = new Touch();
           }
       }
   }
}
