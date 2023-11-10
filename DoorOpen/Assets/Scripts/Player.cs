using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForse;
    [SerializeField] private float JumpCheckDistance;
    [SerializeField] private LayerMask GroundMask;

    [Header("Pdsasdas")]

    private Rigidbody rb;
    [SerializeField] private Transform Camera;
    private float XAngle;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 Movement = transform.forward * MoveZ + transform.right * MoveX;

        rb.velocity = new Vector3(Movement.x * Speed, rb.velocity.y, Movement.z * Speed);

        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, MouseX, 0);

        XAngle -= MouseY;
        XAngle = Mathf.Clamp(XAngle, -90, 90);
        Camera.localRotation = Quaternion.Euler(XAngle, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, JumpCheckDistance, GroundMask))
        {
            rb.AddForce(transform.up * JumpForse);
        }
    }
}
