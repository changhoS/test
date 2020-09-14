using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Missile : MonoBehaviour
{

    public float speed = 4f;
    Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        var colliders = new Collider2D[4];
        Physics2D.OverlapCircleNonAlloc(transform.position, 10, colliders);

        var target = colliders.Where(col => col != null).Aggregate((col1, col2) =>
         {


             var magnitude1 = (col1.transform.position - transform.position).magnitude ;
             var magnitude2 = (col2.transform.position - transform.position).magnitude;


             return magnitude1 > magnitude2 ? col1 : col2;
         });

        if(target != null)
        {

            var dir = ( target.transform.position- transform.position).normalized;
            _rigidbody2D.AddForce(dir * speed);

        }
    }
}
