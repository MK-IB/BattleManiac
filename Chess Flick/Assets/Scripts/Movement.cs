using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum BattleState{PLAYERTURN, ENEMYTURN, WON, LOST}

public class Movement : MonoBehaviour
{
    Vector3 dragStartPos;
    Vector3 draggingPos;
    Vector3 dragReleasePos;

    public BattleState state;

    [SerializeField] private Transform sprite;
    public float power = 1000f;
    public float maxDrag = 50f;
    public Rigidbody rb;
    //public LineRenderer lr;
    bool dragging = false;
    
    private float damping = 100f;

    void Awake()
    {
         sprite.GetComponent<MeshRenderer>().enabled = false;
  
    }
    
    public Vector3 GetPlayerKingPosition()
    {
        return transform.position;
    }

    void OnMouseDown()
    {
        /*if(state != BattleState.PLAYERTURN)
            return; */
        if(IsPointerOverUIObject())
        {
            return ;    
        }
        else
        {
            dragStartPos = Input.mousePosition;
            sprite.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }
    void OnMouseDrag()
    {
        if(IsPointerOverUIObject())
        {
            return;
        }
        else
        {
        FindObjectOfType<CameraRotation>().enabled = false;
        Vector3 draggingPos = Input.mousePosition;
        //Debug.Log("MOUSE POS:"+ Input.mousePosition);
        float distX = (draggingPos.x - dragStartPos.x) / 80;
        float distZ = (draggingPos.y - dragStartPos.y) / 80;
        draggingPos = new Vector3(transform.position.x - distX, 0f, transform.position.z - distZ);

        //sprite.localScale = new Vector3(sprite.localScale.x, 1, distZ / 1000);
        Vector3 lookDir = draggingPos - transform.position;
        lookDir.y = 0;

        Quaternion rotation = Quaternion.LookRotation(-lookDir);
        sprite.rotation = Quaternion.Slerp(sprite.rotation, rotation, Time.deltaTime * damping);
        //sprite.LookAt(draggingPos);
        }
        
    
    }
    void OnMouseUp()
    {
        /*if(state != BattleState.PLAYERTURN)
            return; */
        if(IsPointerOverUIObject())
        {
            return;
        }
        else{
        Vector3 dragReleasePos = Input.mousePosition;

        float distX = (dragReleasePos.x - dragStartPos.x) / 80;
        float distZ = (dragReleasePos.y- dragStartPos.y) / 80;

        dragReleasePos = new Vector3(transform.position.x - distX, 0f , transform.position.z - distZ);
        Vector3 pos1 = transform.position;
        Vector3 pos2 = dragReleasePos;
        Vector3 forceDir = pos1 - pos2;
        
        rb.AddForce(-forceDir * power);
        sprite.GetComponent<MeshRenderer>().enabled = false;
        }
        Debug.Log("Before EnemyTurn()");
         FindObjectOfType<BattleHandler>().EnemyTurn();
        Debug.Log("After EnemyTurn()");
        //state = BattleState.ENEMYTURN;
        //StartCoroutine(MakeEnemyTurn());
        //state = BattleState.PLAYERTURN;
        //FindObjectOfType<BattleHandler>().SetupPlayers();
        
    }

    /*IEnumerator MakeEnemyTurn()
    {
        yield return new WaitForSeconds(1.2f);
        
    } */

    private bool IsPointerOverUIObject() {
     PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
     eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
     List<RaycastResult> results = new List<RaycastResult>();
     EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
     return results.Count > 0;
 }
}
