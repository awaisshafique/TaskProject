﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskController : MonoBehaviour
{


    public GameObject pointA, pointB;


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SpawnAtPointA();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnObject(pointB, pointA);
        }


    }


    public void SpawnAtPointA()
    {
        SpawnObject(pointA, pointB);
    }

    public void SpawnAtPointB()
    {
        SpawnObject(pointB, pointA);

    }

    void SpawnObject(GameObject point , GameObject target)
    {
        var g = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var r = g.AddComponent<Rigidbody>();

        r.useGravity = false;

        g.GetComponent<Collider>().isTrigger = true;
        g.transform.position = point.transform.position;

        var cube = g;

        var moveObject = cube.AddComponent<MoveObject>();

        var speed = Random.Range(1f, 5f);

        moveObject.Init(speed, target.transform);

    }



    public bool CheckIfGameObjectContainsNo(GameObject obj)
    {
        var name = obj.name;

        bool isIntString = name.Any(char.IsNumber);

        return isIntString;
    }

}
