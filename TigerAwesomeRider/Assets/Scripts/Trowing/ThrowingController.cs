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
    [SerializeField] private List<ThrowableObject> Objects;

    private void Update()
    {
        //if (!picked)
        //{
        //    PickUpAround();
        //}
        //else
        //{
        //    Collider[] colliders = Physics.OverlapSphere(transform.position, throwingToTragetDist, throwTargetLayer);
        //
         //   if (colliders.Length > 0 && colliders[0].TryGetComponent(out ThrowableTarget target))
        //    {
        //        Vector3 dir = target.Target.position - transform.position;
        //        dir.Normalize();

        //        picked.transform.parent = null;
         //       picked.Rb.isKinematic = false;

        //        picked.Throw(dir, throwForce);

        //        picked = null;
                //animator.SetBool("InHands", false);
        //    }
        //}
    }

    //private void PickUpAround()
    //{
        //Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpRange, pickUpLayer);

        //if (colliders.Length > 0 && colliders[0].TryGetComponent(out ThrowableObject throwable))
        //{
            //Transform objectTransform = colliders[0].transform;
            //if (freePickUpPointIndex < pickUpPoints.Length) // Убедитесь, что индекс не выходит за пределы массива pickUpPoints
            //{
            //    objectTransform.position = pickUpPoints[freePickUpPointIndex].position; // Устанавливаем позицию объекта
            //    objectTransform.rotation = pickUpPoints[freePickUpPointIndex].rotation; // Устанавливаем вращение объекта (если нужно)
                                                                                        // Другие операции
            //}

       //     if (freePickUpPointIndex > 5) return;
       //     picked = throwable;
      //      picked.transform.parent = pickUpPoints[freePickUpPointIndex];
      //      picked.transform.localPosition = Vector3.zero;
     //       picked.Rb.isKinematic = true;
      //      freePickUpPointIndex++;
     //       //animator.SetBool("InHands", true);
     //   }
    //public Transform firstObjPoint;

    //public List<GameObject> inventory;

    //private void Update()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
//
    //    if (colliders.Length > 0)
     //   {
    //        inventory.Add(colliders[0].gameObject);
//
    //        colliders[0].gameObject.transform.position = firstObjPoint.position + new Vector3(0, inventory.Count + 0.5f, 0);
    //    }
    //}
    //}


}
