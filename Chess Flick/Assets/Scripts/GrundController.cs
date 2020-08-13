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

    private float offset = 0.1f;
    private float speed = 1.5f;


    void Start()
    {
    }

    public void ShowUpBarrier(int num)
    {
        switch(num)
        {
            case 1: barrier = barrier1;
            break;

            case 2: barrier = barrier2;
            break;

            case 3: barrier = barrier3;
            break;

            default: break;
        }
        foreach(Transform bar in barrier)
        {
            bar.DOScaleY(offset, speed);
        }
        if(SceneManager.GetActiveScene().name == "Level 1")
            FindObjectOfType<BattleHandler>().SetupPlayers();
        else FindObjectOfType<BattleHandler>().InitializeSpawning();
    }
}
