using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovozkaItem : MonoBehaviour
{
    public Rigidbody Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }
}
