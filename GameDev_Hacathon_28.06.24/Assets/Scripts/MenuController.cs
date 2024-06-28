using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PlayButton()
    {
        background.transform.position = new Vector3(-480, 0, 0);
        button1.transform.position = new Vector3(-480, 0, 0);
        button2.transform.position = new Vector3(-480, 0, 0);
    }
}
