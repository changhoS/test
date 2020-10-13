using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;


    private void OnEnable()
    {
        Invoke("Hide", 3f);
    }

    void Hide()
    {
        gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision .gameObject .CompareTag("Enemy"))
        {
            var damagable = collision.gameObject.GetComponent<IDamagable>();

            if(damagable != null)
            {
                damagable.Damage(damage);
            }

            gameObject.SetActive(false);
        }


    }

}
