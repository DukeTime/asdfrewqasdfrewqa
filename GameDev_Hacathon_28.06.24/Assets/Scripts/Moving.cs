using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public bool StopMoving = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!StopMoving)
        {
            transform.position += new Vector3(0, 0, -0.63f);
        }
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
}
