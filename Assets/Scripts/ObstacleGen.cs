using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{
    public bool isItem;
    public GameObject[] obj;
    public GameObject item;
    public float time;
    int index = 0;
    int position;
    
    void Start()
    {
        InvokeRepeating("Spawn", 0, time);
    }
    void Spawn()
    {
        index = Random.Range(0, obj.Length);
        if (Random.Range(1,4) == 1)
        {
            transform.position = new Vector3(0, 0, 20);
        }else if (Random.Range(1,4) == 2)
        {
            transform.position = new Vector3(.5f, 0, 20);
        }
        else if( Random.Range(1,4) == 3)
        {
            transform.position = new Vector3(-.5f, 0, 20);
        }

        if (isItem)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }else
            Instantiate(obj[index], transform.position, Quaternion.identity);

    }
    void PosChange()
    {
        

    }
    
}
