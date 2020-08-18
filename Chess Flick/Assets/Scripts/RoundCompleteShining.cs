using DG.Tweening;
using UnityEngine;

public class RoundCompleteShining : MonoBehaviour
{
    public float offset;
    public float speed;
    public float mindelay;
    public float maxdelay;

    void Start()
    {
        Animate();
    }

    void Animate()
   {
      transform.DOLocalMoveX(offset, speed).SetEase(Ease.Linear).SetDelay(Random.Range(mindelay, maxdelay)).
      OnComplete(()=> {
          transform.DOLocalMoveX(-offset, 0);
          Animate();
      });
   }
}
