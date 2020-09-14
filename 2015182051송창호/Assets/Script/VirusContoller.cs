using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusContoller : MonoBehaviour
{
    public float _maxHealth = 2f;
    public float speed= 3;
    private Rigidbody2D _rigidbody2D;


    private float _health;
    // Start is called before the first frame update

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EventManager.On("game_ended", OnGameEnded);
    }


    private void OnGameEnded(object obj)
    {


        gameObject.SetActive(false);
    }



    private void Update()
    {
        Vector2 velocity;


        if (GameManager.instance.state == GameState.Playing)
            velocity = Vector2.left;
        else
            velocity = Vector2.zero;

        _rigidbody2D.velocity = velocity*speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var man = other.GetComponent<Man>();
            man.Damage(1f);

            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Missile"))
        {

            other.gameObject.SetActive(false);
            _health -= 1f;

            if(_health <= 0)
            {
                gameObject.SetActive(false);
            }

        }
     
    }



    private void OnEnable()
    {
        _health = _maxHealth;
    }

}
