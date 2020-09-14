using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButtounUi : MonoBehaviour
{

    public void Clicked()
    {
        EventManager.Emit("game_started", null);

    }
}
