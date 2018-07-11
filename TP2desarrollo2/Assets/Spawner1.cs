using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner1: MonoBehaviour
{

    [SerializeField] float tiempo;
    public GameObject prefab;

    void Awake()
    {
        Invoke("Spawn", tiempo);
    }

    void Spawn()
    {
        var go = Instantiate(prefab);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        Invoke("Spawn", tiempo);
    }


}

