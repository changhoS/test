using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatePrinter : MonoBehaviour
{


    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }



    void Update()
    {

        _text.text = GameManager.instance.state.ToString();

        
    }
}
