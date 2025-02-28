﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;




    public Animator animator;
    public int a;
    int number;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ButtonClick(int scene_number)
    {

        number = scene_number;
        // Воспроизводим анимацию
        animator.Play("Название_анимации");
            
        // Загружаем следующую сцену после завершения анимации
        Invoke("LoadNextScene", animator.GetCurrentAnimatorStateInfo(0).length);


    }
    private void LoadNextScene(int scnumber)
    {
        SceneManager.LoadScene(scnumber);
    }
}
