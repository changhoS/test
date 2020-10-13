using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]public struct Stat
{

    [SerializeField] private float maxHp;
    public float current_hp;

    public float MaxHp
    {
        get
        {

            return maxHp;
        }



    }


}
