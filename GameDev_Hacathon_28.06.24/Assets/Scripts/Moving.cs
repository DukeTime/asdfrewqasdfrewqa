using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Moving : MonoBehaviour
{
    public string FishType;
    private string[] FishesI = { "Щука", "Осётр", "Горбуша", "Карп", "Судак", "Толстолобик" };
    private string[] FishesII = { "Сом", "Угорь", "Пиранья"};
    [SerializeField] private Dictionary<string, int> typeDict = new Dictionary<string, int>()
    {
        {"Щука", 2},
        {"Осётр", 2}
    };
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float start_fish_x;
    private int jump_plan = 0;
    public bool StopMoving = false; 
    System.Random ran = new System.Random();
    void Start()
    {
        FishType = FishesI[ran.Next(0, 2)];
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
        while (transform.position.z > -20)
        {
            float timer = 0;
            rb.velocity = Vector3.zero;
            while (jump_plan == 0)
                jump_plan = ran.Next(-3, 3);
            //Vector3 point = fish_pos + new Vector3(ran.Next(-14, 14), 0, ran.Next(-5, 12));
            transform.rotation = Quaternion.Euler(0, jump_plan > 0 ? 90 : -90, 0);
            rb.AddForce(jump_plan > 0 ? Vector3.right * 400f : Vector3.left * 400f);
            jump_plan += jump_plan > 0 ? -1 : 1;
            while (timer < 1)
            {
                transform.Translate(Vector3.left * 0.065f);
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
                        rb.AddForce(new Vector3(ran.Next(300, 350), 0, -10));
                    }
                    else
                    {
                        //transform.Translate(new Vector3(ran.Next(-3, -1), 0, ran.Next(-3, -1)));
                        rb.AddForce(new Vector3(ran.Next(-350, -300), 0, -10));
                    }
                }
                //transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime * 15);
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
