using DG.Tweening;
using UnityEngine;

public class GrundController : MonoBehaviour
{
    public GameObject touchEffect;
    public Transform[] barriers;
    public GameObject level1UI;

    private float offset = 0.1f;
    private float speed = 1.5f;


    void Start()
    {
        if(!level1UI)
            return;
        level1UI.SetActive(true);
    }
    public void HideLevel1UI()
    {
        if(level1UI)
            level1UI.SetActive(false);
        ShowUpBarrier();
    }

    public void ShowUpBarrier()
    {
        foreach(Transform barrier in barriers)
        {
            barrier.DOScaleY(offset, speed);
        }
    }
}
