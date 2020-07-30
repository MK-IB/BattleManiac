using DG.Tweening;
using UnityEngine;

public class GrundController : MonoBehaviour
{
    public GameObject touchEffect;
    public Transform[] barriers;

    private float offset = 0.1f;
    private float speed = 1.5f;

        public void ShowUpBarrier()
        {
            foreach(Transform barrier in barriers)
            {
                barrier.DOScaleY(offset, speed);
            }
        }
}
