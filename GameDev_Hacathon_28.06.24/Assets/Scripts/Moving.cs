using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private int jump_plan = 0;
    public bool StopMoving = false;
    System.Random ran = new System.Random();
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
    public IEnumerator FishDodjing(Vector3 fish_pos)
    {
        while (transform.position.z > -5)
        {
            float timer = 0;
            while (jump_plan == 0)
                jump_plan = ran.Next(-3, 3);
            //Vector3 point = fish_pos + new Vector3(ran.Next(-14, 14), 0, ran.Next(-5, 12));
            transform.rotation = Quaternion.Euler(90, jump_plan > 0 ? 90 : -90, 0);
            rb.AddForce(Vector3.right * 100f);
            jump_plan += jump_plan > 0 ? -1 : 1;
            if (transform.position.x > 15)
            {
                //dfvnjdfnvjdnfvdfvdfvdfvdf
            }
            while (timer < 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.x > 562.5)
                    {
                        //transform.Translate(new Vector3(ran.Next(1, 3), 0, ran.Next(-3, -1)));
                        rb.AddForce(new Vector3(ran.Next(40, 60), 0, ran.Next(-30, -10)));
                    }
                    else
                    {
                        //transform.Translate(new Vector3(ran.Next(-3, -1), 0, ran.Next(-3, -1)));
                        rb.AddForce(new Vector3(ran.Next(-60, -40), 0, ran.Next(-30, -10)));
                    }
                }
                //transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime * 15);
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
