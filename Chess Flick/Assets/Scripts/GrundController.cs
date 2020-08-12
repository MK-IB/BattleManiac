using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().name == "Level 1")
            return;
        else FindObjectOfType<BattleHandler>().InitializeSpawning();
    }
}
