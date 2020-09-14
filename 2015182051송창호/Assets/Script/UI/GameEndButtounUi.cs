using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndButtounUi : MonoBehaviour
{
    // Start is called before the first frame update
  public void Clicked()
    {

        EventManager.Emit("game_ended", null);

    }
}
