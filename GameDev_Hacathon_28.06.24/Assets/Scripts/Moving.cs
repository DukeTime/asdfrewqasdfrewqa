using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float start_fish_x;
    private int jump_plan = 0;
    public bool StopMoving = false;
    System.Random ran = new System.Random();
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!StopMoving)
        {
            transform.position += new Vector3(0, 0, -0.4f);
        }
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator FishDodjing(Vector3 fish_pos)
    {
        start_fish_x = transform.position.x;
        while (transform.position.z > -5)
        {
            float timer = 0;
            rb.velocity = Vector3.zero;
            while (jump_plan == 0)
                jump_plan = ran.Next(-3, 3);
            //Vector3 point = fish_pos + new Vector3(ran.Next(-14, 14), 0, ran.Next(-5, 12));
            transform.rotation = Quaternion.Euler(90, jump_plan > 0 ? 90 : -90, 0);
            rb.AddForce(jump_plan > 0 ? Vector3.right * 200f : Vector3.left * 200f);
            jump_plan += jump_plan > 0 ? -1 : 1;
            while (timer < 1)
            {
                if (transform.position.x - start_fish_x > 12)
                {
                    rb.velocity = new Vector3(rb.velocity.x > 0 ? 0 : rb.velocity.x, rb.velocity.y, rb.velocity.z);
                    rb.isKinematic = false;
                }
                else if (transform.position.x - start_fish_x < -12)
                {
                    rb.velocity = new Vector3(rb.velocity.x > 0 ? rb.velocity.x : 0, rb.velocity.y, rb.velocity.z);
                    rb.isKinematic = false;
                }
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
        FishingEnding();
    }
    private void FishingEnding()
    {

    }
}
