﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPenguin : MonoBehaviour
{
    float speed;
    public GameObject enemy;
    public float xPositionLmit;
    public float yPositionLimit;
    public float SpawnRate;

    void Start()
    {
        speed = 2f;
    }
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);

        transform.position = position;


        if (transform.position.x < xPositionLmit)
        {
            Destroy(gameObject);
        }

    }
}
