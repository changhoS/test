using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    public string missileName = "missile";
    public float maxHealth;
    public float throwRate = 0.5f;


    private float _health;
    private Coroutine  _throwRoutin;


    public float Health => _health;
  

    // Start is called before the first frame update
    void Start()
    {


        EventManager.On("game_started", OnGameStart);
        EventManager.On("game_ended", OnGameEnded);

        gameObject.SetActive(false);
    }


    private void OnGameStart(object obj)
    {


        _health = maxHealth;
        gameObject.SetActive(true);

       _throwRoutin  = StartCoroutine(ShootRoutin());
    }


    private void OnGameEnded(object obj)
    {

        StopCoroutine(_throwRoutin);
        gameObject.SetActive(false);


    }



    public void Damage(float damage)
    {

        _health -= damage;


        if (_health <= 0)
        {
            EventManager.Emit("game_ended", null);
        }
    }

    private IEnumerator ShootRoutin()
    {


        while (true)
        {

            var go = ObjectPoolManager.instance.Spawn(missileName);
            
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;

            yield return new WaitForSeconds(throwRate);



        }
    }

}
