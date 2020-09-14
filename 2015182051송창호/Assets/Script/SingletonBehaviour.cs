using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    // Start is called before the first frame update

    private static T _instance;
    public static T instance
    {
        get
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                var go = new GameObject(typeof(T).Name );
                _instance = go.AddComponent<T>();
            }

            return _instance;
        }

    }



}
