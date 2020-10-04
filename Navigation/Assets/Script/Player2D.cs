using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Player2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 10f;
    private Seeker _seeker;
    private void Awake()
    {
        _seeker = GetComponent<Seeker>();
    }

    private void Start()
    {
        StartCoroutine(PathRoutin());

    }

    IEnumerator PathRoutin()
    {
        var index = 0;
        var offset = 0.1f;
        var path = _seeker.StartPath(transform.position, target.position);


        yield return path.WaitForPath();


        foreach (var pos in path.vectorPath)
        {
            var targetPos = pos;
            var vec = targetPos - transform.position;

            while (this.enabled)
            {
                transform.Translate(vec.normalized * Time.deltaTime * speed);

                var dist = vec.magnitude;

                if (dist <= offset)
                {
                    index++;
                    yield break;
                }

                yield return null;

            }

        }
    }

}
