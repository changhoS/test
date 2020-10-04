using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float speed; //속도
    [SerializeField] private float angular_speed;
    [SerializeField] private float acceleration_speed;
    private NavMeshAgent _agent;

    private void Awake()
    {

        _agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {

        _agent.speed = speed;
        _agent.angularSpeed = angular_speed;
        _agent.acceleration = acceleration_speed; 

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var mousePos = Input.mousePosition;
            var ray = cam.ScreenPointToRay(mousePos);
           if( Physics.Raycast(ray, out var raycastHit,layer))
            {
                _agent.SetDestination(raycastHit.point);

            }
        }
    }

}
