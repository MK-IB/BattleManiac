using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrundController : MonoBehaviour
{
    public GameObject touchEffect;
    private Transform[] barrier;
    public Transform[] barrier1;
    public Transform[] barrier2;
    public Transform[] barrier3;
    public GameObject level1UI;

    private float finalScale = 0.1f;
    private float currentScale;
    private float speed = 1.5f;

    Tweener scaleTween;

    void Start()
    {
        //foreach(GameObject slab in GameObject.FindGameObjectsWithTag("slab"))
                //slab.SetActive(false);
    }

    public void ShowUpBarrier(int num)
    {
        switch(num)
        {
            case 1: 
            foreach(GameObject slab in GameObject.FindGameObjectsWithTag("slab"))
            {
                //slab.SetActive(true);
                slab.GetComponent<Animator>().SetBool("startSlabExpandAnim", true);
            }
            break;

            case 2:
            foreach(GameObject slab in GameObject.FindGameObjectsWithTag("slab2"))
            {
                //slab.SetActive(true);
                slab.GetComponent<Animator>().SetBool("startSlabExpandAnim", true);
            }
            break;

            case 3: barrier = barrier3;
            break;

            default: break;
        }
        /*foreach(Transform bar in barrier)
        {
            bar.DOScaleY(finalScale, speed);
        } */
        
        FindObjectOfType<BattleHandler>().InitializeSpawning();
        FindObjectOfType<AnimationController>().DestroySlab();
    }

    public void HideBarrier(int num)
    {
        switch(num)
        {
            case 1:
            foreach(GameObject slab in GameObject.FindGameObjectsWithTag("slab"))
            {
                //slab.SetActive(true);
                slab.GetComponent<Animator>().SetBool("startSlabShrinkAnim", true);
                slab.SetActive(false);
            }
            break;

            case 2:
            foreach(GameObject slab in GameObject.FindGameObjectsWithTag("slab2"))
            {
                //slab.SetActive(true);
                slab.GetComponent<Animator>().SetBool("startSlabShrinkAnim", true);
            }
            break;
        }
        
    }
}
