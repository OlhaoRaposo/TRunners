using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float speed;
    public float dstime;
     void Start()
    {
        Destroy(gameObject,dstime);
    }

    void Update()
    {
        transform.Translate(0,0,(-speed * Time.deltaTime)); 
    }
}
