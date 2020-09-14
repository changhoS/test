using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUi : MonoBehaviour
{
    private Slider _silder;
    public Man man;



    private void Awake()
    {
        _silder = GetComponent<Slider>();
    }


    private void Start()
    {
        EventManager.On("game_started", OnGameStart);
        EventManager.On("game_ended", OnGameEnded);
        gameObject.SetActive(false);
    }

    private void OnGameEnded(object obj)
    {

        gameObject.SetActive(false);

    }

    private void OnGameStart(object obj)
    {
        gameObject.SetActive(true);


    }


    private void Update()
    {
        _silder.value  = man.Health / man.maxHealth; 
    }

}
