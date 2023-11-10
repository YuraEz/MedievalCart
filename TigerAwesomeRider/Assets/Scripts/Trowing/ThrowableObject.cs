using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ThrowableObject : MonoBehaviour
{
    public Rigidbody Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    public void Throw(Vector3 dir, float force)
    {
        Rb.AddForce(dir * force, ForceMode.Impulse);
    }
}
