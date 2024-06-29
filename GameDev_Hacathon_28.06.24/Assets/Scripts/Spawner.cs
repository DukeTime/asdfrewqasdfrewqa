using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject splashPrefab;
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
                x = ran.Next(5,14) * (ran.Next(0, 2) == 0 ? -1 : 1);
                pos = new Vector3(x, y, z);
                Instantiate(fishPrefab, pos, Quaternion.Euler(90,0,0));
                Instantiate(splashPrefab, pos, Quaternion.Euler(90,0,0));
            }
        }
    }
}