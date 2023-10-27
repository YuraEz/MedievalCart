using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingController : MonoBehaviour
{
    //[SerializeField] private Transform pickUpPoint;
    [SerializeField] private Transform[] pickUpPoints;
    private int freePickUpPointIndex = 0; // Индекс текущей точки
    [SerializeField] private Animator animator;

    [Space]
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private float pickUpRange;

    [Space]
    [SerializeField] private LayerMask throwTargetLayer;
    [SerializeField] private float throwingToTragetDist;
    [SerializeField] private float throwForce = 50;

    [Space]
    [SerializeField] private ThrowableObject picked;

    private void Update()
    {
        if (!picked)
        {
            PickUpAround();
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, throwingToTragetDist, throwTargetLayer);

            if (colliders.Length > 0 && colliders[0].TryGetComponent(out ThrowableTarget target))
            {
                Vector3 dir = target.Target.position - transform.position;
                dir.Normalize();

                picked.transform.parent = null;
                picked.Rb.isKinematic = false;

                picked.Throw(dir, throwForce);

                picked = null;
                //animator.SetBool("InHands", false);
            }
        }
    }

    private void PickUpAround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpRange, pickUpLayer);

        if (colliders.Length > 0 && colliders[0].TryGetComponent(out ThrowableObject throwable))
        {
            if (freePickUpPointIndex > 5) return;
            picked = throwable;
            picked.transform.parent = pickUpPoints[freePickUpPointIndex];
            picked.transform.localPosition = Vector3.zero;
            picked.Rb.isKinematic = true;
            freePickUpPointIndex++;
            //animator.SetBool("InHands", true);
        }


    }
}
