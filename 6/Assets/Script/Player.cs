using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KPU.Manager;
using KPU.Controllers;
using KPU.Time;
public class Player : MonoBehaviour,IDamagable
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Stat status;
    [SerializeField] private float attackPower =1f;
    [SerializeField] private float attackRate= 0.25f;
    [SerializeField] private float attackShootSpeed = 20f;
    private NavMeshAgent _agent;
    private PlayerState _state;
    private float _attackTimer;
    private void Awake()
    {
        
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if(GameManager .Instance .State == KPU.State.GameEnded)
        {
            return;
        }


        var dir = (cam.transform.forward*Input.GetAxis ("Vertical") + cam.transform.right*Input .GetAxis ("Horizontal")).normalized  ; 
            
            _agent.Move(new Vector3(dir.x,0,dir.z) * (Time.deltaTime *speed ));


        //회전 
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)); 


        //shoot

        if(Input .GetKey(KeyCode.Space))
        {
            if(_attackTimer > attackRate)
            {
               var bulletGameobject =ObjectPoolManager.Instance.Spawn("bullet", transform.position);
                var rigidBody = bulletGameobject.GetComponent<Rigidbody>();

                rigidBody.AddForce(transform.forward * attackShootSpeed, ForceMode.Impulse);
                _attackTimer = 0;
            }

        }
        _attackTimer += Time.deltaTime;


    }

    private void OnEnable()
    {
        _state = PlayerState.Idle;
        status.current_hp = status.MaxHp;
    }


    public void Damage(float damageAmount)
    {

        status.current_hp =Mathf.Clamp ( status.current_hp - damageAmount,0,status.MaxHp );
        if(status .current_hp  <= 0)
        {
            _state = PlayerState.Dead;
            EventManager.Emit("game_over");
            EventManager.Emit("game_ended");
            
        }
    }
}
