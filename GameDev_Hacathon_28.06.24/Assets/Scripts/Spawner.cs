using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public int maxFish = 25;
    public float distance = 3;
    public float timeSpawn = 2f;
    System.Random ran = new System.Random();
    public float x;
    public float y = -10.3f;
    public float z;
    Vector3 pos;

    private void Start()
    {

    }

    private void Update()
    {
        timeSpawn -= Time.deltaTime;
        if (timeSpawn <= 0)
        {
             timeSpawn = ran.Next(1,5);
            if (transform.childCount < maxFish)
            {
                x = ran.Next(-14,16);
                z = ran.Next(34,36);
                pos = new Vector3(x, y, z);
                Instantiate(fishPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}