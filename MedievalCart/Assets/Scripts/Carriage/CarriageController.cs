using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarriageController : MonoBehaviour
{
    private Transform[] waypoints; // Массив для хранения всех точек, которые куб должен посетить
    [SerializeField] private int ChosenRoad;
    private int currentWaypointIndex = 0; // Индекс текущей точки


    [SerializeField] private float moveSpeed = 5f; // Скорость движения куба
    [SerializeField] private float Healths;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private LayerMask CarriageMask;
    [SerializeField] private float AttackRange;

    public static CarriageController Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (ChosenRoad == 1)
        {
            waypoints = CarriageSpawner.Instance.WayPoints1;
            return;
        }
        waypoints = CarriageSpawner.Instance.WayPoints2;
        MoveToWaypoint(waypoints[currentWaypointIndex]);
    }


    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, AttackRange, CarriageMask))
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 2f)
        {

            // Если достиг, переходим к следующей точке
            currentWaypointIndex++;

            // Если достигли финиша, останавливаем удоляем обьект
            if (currentWaypointIndex >= waypoints.Length)
            {
                enabled = false;
                Destroy(gameObject);
                return;
            }

            // В противном случае, продолжаем двигаться к следующей точке

        }
        MoveToWaypoint(waypoints[currentWaypointIndex]);
    }

    private void MoveToWaypoint(Transform waypoint)
    {
        // Направляем куб к следующей точке
        Vector3 direction = (waypoint.position - transform.position);


        Quaternion LookRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRot, Time.deltaTime * rotationSpeed);
    }

    public void TakeDamage(float damageAmount)
    {
        Healths -= damageAmount;

        if (Healths < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * AttackRange);
    }
}
