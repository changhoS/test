using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : SingletonBehaviour <EventManager>
{
    // Start is called before the first frame update

    private IDictionary<string, List<Action<object>>> _eventDatabase;


    private void Awake()
    {

        _eventDatabase = new Dictionary<string, List<Action<object>>>();


    }



    public static void On(string eventName, Action<object> subscript)
    {

        if(instance._eventDatabase.ContainsKey(eventName) == false)
        {
            instance._eventDatabase.Add(eventName, new List<Action<object>>());
        }


        instance._eventDatabase[eventName].Add(subscript);


    }

    public static void Emit(string eventName, object parameter)
    {

        if(instance._eventDatabase .ContainsKey(eventName) == false)
        {

            Debug.LogWarning($"{eventName}존재하지않습니다.");
            return;
        }


        foreach(var action in instance._eventDatabase[eventName])
        {
            action(parameter);
        }


    }


}
