﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Moving : MonoBehaviour
{
    public bool MobilePlatform = false;
    public string FishType;
    private string[] FishesI = { "Щука", "Осётр", "Горбуша", "Карп", "Судак", "Толстолобик" };
    private string[] FishesII = { "Сом", "Угорь", "Пиранья" };

    private string[] Fishes = { "Карп", "Осётр", "Горбуша", "Щука", "Толстолобик", "Судак", "Голавль", "Сом", "Угорь", "Пиранья", "Арапаима", "Акула", "Скат", "Краб" };
    [SerializeField] private Dictionary<string, int> strenghtDict = new Dictionary<string, int>()
    {
        {"Щука", 3},
        {"Осётр", 3},
        {"Горбуша", 2},
        {"Карп", 2},
        {"Судак", 3},
        {"Толстолобик", 3},
        {"Голавль", 4},
        {"Пиранья", 1},
        {"Сом", 5},
        {"Угорь", 5},
        {"Акула", 7},
        {"Арапаима", 5},
        {"Скат", 6},
        {"Краб", 1}
    };
    [SerializeField]
    private Dictionary<string, Vector3> sizeDict = new Dictionary<string, Vector3>()
    {
        {"Щука", new Vector3(0.3f, 0.3f, 0.3f)},
        {"Осётр", new Vector3(0.3f, 0.3f, 0.3f)},
        {"Горбуша", new Vector3(0.2f, 0.4f, 0.2f)},
        {"Карп", new Vector3(0.2f, 0.4f, 0.2f)},
        {"Судак", new Vector3(0.3f, 0.3f, 0.3f)},
        {"Толстолобик", new Vector3(0.3f, 0.3f, 0.3f)},
        {"Голавль", new Vector3(0.4f, 0.4f, 0.4f)},
        {"Пиранья", new Vector3(0.1f, 0.2f, 0.2f)},
        {"Сом", new Vector3(0.5f, 0.5f, 0.5f)},
        {"Угорь", new Vector3(0.35f, 0.35f, 1.2f)},
        {"Акула", new Vector3(0.8f, 0.8f, 0.8f)},
        {"Арапаима", new Vector3(0.6f, 0.6f, 0.6f)},
        {"Скат", new Vector3(5, 0.1f, 1.2f)},
        {"Краб", new Vector3(0.1f, 0.1f, 0.1f)}
    };
    [SerializeField] private Rigidbody rb;
    private RibakAnim ranim;
    private int strenght;
    private int jump_plan = 0;
    public float start_fish_x;
    public float start_fish_z;
    public bool StopMoving = false; 

    public bool IsSucces = false;
    System.Random ran = new System.Random();
    void Start()
    {
        ranim = GameObject.FindGameObjectWithTag("RodAnim").GetComponent<RibakAnim>();
        if (ranim.FishingProgress < 14)
        {
            ranim.FishingProgress += 1;
        }
        FishType = Fishes[ran.Next(0, ranim.FishingProgress)];
        strenght = strenghtDict[FishType];
        transform.localScale = sizeDict[FishType];
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
        start_fish_z = transform.position.z;
        while (!IsSucces)
        {
        
            float timer = 0;
            rb.velocity = Vector3.zero;
            while (jump_plan == 0)
                jump_plan = ran.Next(-3, 3);
            //Vector3 point = fish_pos + new Vector3(ran.Next(-14, 14), 0, ran.Next(-5, 12));
            transform.rotation = Quaternion.Euler(0, jump_plan > 0 ? 90 : -90, 0);
            rb.AddForce(jump_plan > 0 ? Vector3.right * (100f * strenght + 200f) : Vector3.left * (100f * strenght + 200f));
            jump_plan += jump_plan > 0 ? -1 : 1;
            ranim.RodAnim(0);
            while (timer < 1)
            {
                transform.position += new Vector3(0, 0, -0.045f);
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
                if (MobilePlatform)
                {
                    if (Input.touchCount != 0)
                    {
                        if (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x > 540)
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

                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Input.mousePosition.x > 540)
                        {
                            //transform.Translate(new Vector3(ran.Next(1, 3), 0, ran.Next(-3, -1)));
                            ranim.RodAnim(1);
                            rb.AddForce(new Vector3(ran.Next(300, 350), 0, -10));
                        }
                        else
                        {
                            //transform.Translate(new Vector3(ran.Next(-3, -1), 0, ran.Next(-3, -1)));\
                            ranim.RodAnim(2);
                            rb.AddForce(new Vector3(ran.Next(-350, -300), 0, -10));
                        }
                    }
                }
                //transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime * 15);
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
