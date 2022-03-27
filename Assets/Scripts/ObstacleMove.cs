using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed;
    public float time;
    void Start()
    {
        Destroy(gameObject,time);
    }

    void Update()
    {
        transform.Translate(0,0, -speed * Time.deltaTime); 
    }
}
