using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class GameOverUI : MonoBehaviour
{

    private void Start()
    {
        EventManager.On("game_over", OnGameOver);

        gameObject.SetActive(false);
    } 

    void OnGameOver(object obj)
    {
        gameObject.SetActive(true);

    }
}
