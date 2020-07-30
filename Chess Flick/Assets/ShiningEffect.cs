using UnityEngine;
using DG.Tweening;

public class ShiningEffect : MonoBehaviour
{

    public Transform shine;
    public float offset;
    public float speed;
    public float mindelay;
    public float maxdelay;
    private Vector3 pos = new Vector3(77.6f, 0f, 0f);

   void Start()
   {
       Animate();
       ScaleAnimation();
   }

   void Animate()
   {
      shine.DOLocalMoveX(offset, speed).SetEase(Ease.Linear).SetDelay(Random.Range(mindelay, maxdelay)).
      OnComplete(()=> {
          shine.DOLocalMoveX(-offset, 0);
          Animate();
      });
   }

   void ScaleAnimation()
   {
       transform.DOScale(new Vector3(1.8f, 1.3f, 1.10f), 0.5f).
        OnComplete(()=> {
            transform.DOScale(new Vector3(1.61f, 1.01f, 1.10f), 0.5f);
            ScaleAnimation();
        });
   }
}
