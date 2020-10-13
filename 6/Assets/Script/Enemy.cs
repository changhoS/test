using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KPU.Manager;
public class Enemy : MonoBehaviour,IDamagable
{
    [SerializeField] private float sightLevel = 0.4f;
    [SerializeField] private float sightLength = 4f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private float attackPower = 1f;
    [SerializeField] private LayerMask layerToCast;
    [SerializeField] private Stat status;


    private NavMeshAgent _agent;
    private Player _player;
    private EnemyState _state;
    private float _attackTimer;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>(); 
    }

    private void OnEnable()
    {
        _state = EnemyState.Idle; 
        StartCoroutine(LifeRoutine());
    }


    private IEnumerator LifeRoutine()
    {
        while(_state != EnemyState.Dead)
        {
            if(_state == EnemyState.Idle)
            {

                _state = EnemyState.Search;
            }else if(_state == EnemyState.Search)
            {
                //시야각 로직
                Search();
               

            }else if(_state == EnemyState.Chase)
            {
                Chase();
            }
            else if(_state  == EnemyState.Attack)
            {
                Attack();
            }


            if(GameManager .Instance .State == KPU.State.GameEnded)
            {
                _state = EnemyState.Dead;
                break;
            }
            yield return null;
        }

        //Dead

        gameObject.SetActive(false);


    }


    private void Search()
    {

        var dir = (_player.transform.position - transform.position).normalized;
        var dot = Vector3.Dot(transform.forward, dir);

        if (dot > sightLevel)
        {

            if (Physics.Raycast(transform.position, dir, out var raycastHit, sightLength, layerToCast))
            {
                var hitObject = raycastHit.collider.gameObject;
                if (hitObject.CompareTag("Player"))
                {
                    _state = EnemyState.Chase;

                }
            }


        }

    }
    private void Chase()
    {

        _agent.isStopped = false;
        if ((_player.transform.position - transform.position).magnitude < attackRange)
        {
            _state = EnemyState.Attack;
        }
        else
        {
            _agent.SetDestination(_player.transform.position);
        }
    }

    private void Attack()
    {
        _agent.isStopped = true;

        if ((_player.transform.position - transform.position).magnitude < attackRange)
        {

            if (_attackTimer > attackRate)
            {
                _player.Damage(attackPower);

                _attackTimer = 0;
            }
            else
            {

                _attackTimer += Time.deltaTime;
            }
        }
        else
        {
            _state = EnemyState.Idle;
        }
    }

    public void Damage(float damageAmount)
    {

        status.current_hp = Mathf.Clamp(status.current_hp - damageAmount,0,status.MaxHp );

        if(status .current_hp <= 0)
        {

            _state = EnemyState.Dead;
        }

    }
}
