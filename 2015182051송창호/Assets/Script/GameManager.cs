using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> 
{
    // Start is called before the first frame update

    public GameState state;

    public void Start()
    {


        EventManager.On("game_started",OnGameStart);
        EventManager.On("game_paused", OnGamePause);
        EventManager.On("game_ended", OnGameEnded);

    }


    public void OnGameStart(object obj)
    {

        state = GameState.Playing;

    }

    private void OnGamePause(object obj)
    {

        state = GameState.Paused;
    }

    public void OnGameEnded(object obj)
    {

        state = GameState.Ended;

    }

}
