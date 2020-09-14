using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;




public class ObjectPoolManager : SingletonBehaviour<ObjectPoolManager>
{
    
    
    
    
    [Serializable]
    public class ObjectPoolData
    {
        public string name;
        public GameObject prefab;


    }

    public List<ObjectPoolData> prefabs;
    private IDictionary<string, List<GameObject>> _objectPool;


    private void Awake()
    {
        _objectPool = new Dictionary<string, List<GameObject>>();
    }


    public GameObject Spawn(string spawnTargetName)
    {

        if(_objectPool.ContainsKey(spawnTargetName) == false)
        {

            _objectPool.Add(spawnTargetName, new List<GameObject>());

        }


        var founded = _objectPool[spawnTargetName].FirstOrDefault(go => !go.activeInHierarchy);

        if(founded == null)
        {
            var foundedPrefab = prefabs.FirstOrDefault(prefabData => prefabData.name == spawnTargetName);
            if (foundedPrefab == null)
            {

                Debug.LogWarning($"{spawnTargetName}이라는 prefab이 존재하지 않습니다.");
                return null;

            }

            founded = Instantiate(foundedPrefab.prefab);
            _objectPool[spawnTargetName].Add(founded);
        }

        founded.SetActive(true);

     
        return founded;

    }
 }

