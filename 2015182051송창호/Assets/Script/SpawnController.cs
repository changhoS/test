using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnController : MonoBehaviour
{


    public float spawnRate = 2;
    public string spawnTargetName = "Virus";
    private Coroutine _spawnRoutin;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.On("game_started", OnGameStart);
        EventManager.On("game_paused", OnGamePause);
        EventManager.On("game_ended", OnGameEnded);
     
    }


    private void OnGameStart(object obj)
    {
        _spawnRoutin =  StartCoroutine(SpawnRoutin());


    }

  private void OnGamePause(object obj)
    {
        StopCoroutine(_spawnRoutin);

    }
    private void OnGameEnded(object obj)
    {
        StopCoroutine(_spawnRoutin);

    }



    private IEnumerator SpawnRoutin()
    {


        while (true)
        {

            var go =ObjectPoolManager.instance.Spawn(spawnTargetName);
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            yield return new WaitForSeconds(spawnRate);
        }
    }

}
