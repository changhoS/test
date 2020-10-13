using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class GameStartUI : MonoBehaviour
{

    public void GameStart()
    {


        EventManager.Emit("game_started");
    }
}

