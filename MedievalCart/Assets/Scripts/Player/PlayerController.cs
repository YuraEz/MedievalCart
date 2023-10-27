//using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public enum PlayerState { OnShip, Action }

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerEnterPoint;

    [Space]
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    [Space]
    [SerializeField] private float moveSpeed;

    [Space]
    [SerializeField] private PlayerState state;
    //[ReadOnly, SerializeField] private PlayerState state;

    //private HealthComponent health;

    private void Awake()
    {
        //health = GetComponent<HealthComponent>();
        //health.onDie += Die;
    }

    private void OnDestroy()
    {
        //health.onDie -= Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (state != PlayerState.Action) return;

        Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);


        if (movement != Vector3.zero)
        {
            // Вычисляем целевой угол поворота на основе направления движения.
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Плавно интерполируем текущий угол поворота к целевому углу поворота.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);

            // Перемещаем персонаж.
            rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);
        }
        //rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);

       // transform.rotation = Quaternion.LookRotation(movement);
        //animator.SetBool("IsMove", movement != Vector3.zero);
    }

    public void ChangeState(PlayerState newState)
    {
        state = newState;

        if (state == PlayerState.Action)
        {
            transform.position = playerEnterPoint.position;
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
    }
}
