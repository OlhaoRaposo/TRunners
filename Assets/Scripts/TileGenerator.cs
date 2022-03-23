using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tile;
    public int time;
    void Start()
    {
        InvokeRepeating("Spawn",0,time);
    }

    void Spawn()
    {
        Instantiate(tile,transform.position,Quaternion.identity);
    }
}
