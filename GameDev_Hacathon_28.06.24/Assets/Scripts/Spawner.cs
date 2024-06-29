using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public int maxFish = 25;
    public float distance = 3;
    public float timeSpawn = 2f;
    public float x = 0f;
    public float y = -10.3f;
    public float z = 38f;
    public bool StopSpawning = false;
    Vector3 pos;
    System.Random ran = new System.Random();

    private void Start()
    {

    }
    
    private void Update()
    {
        if (!StopSpawning)
        {
            timeSpawn -= Time.deltaTime;
            if (timeSpawn <= 0)
            {
                 timeSpawn = ran.Next(3,5);
                if (transform.childCount < maxFish)
                {
                    x = ran.Next(-14,14);
                    //z = ran.Next(34,36);
                    pos = new Vector3(x, y, z);
                    Instantiate(fishPrefab, pos, Quaternion.Euler(90,0,0));
                }
            }
        }
    }
}