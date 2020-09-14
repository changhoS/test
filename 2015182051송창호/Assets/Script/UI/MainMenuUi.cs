using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        EventManager.On("game_started", Hide);
        EventManager.On("game_ended", Show);
        EventManager.On("game_paused", Show);

    }



    private void Show(object obj)
    {

        gameObject.SetActive(true);


    }


    private void Hide(object obj)
    {


        gameObject.SetActive(false);


    }
}
