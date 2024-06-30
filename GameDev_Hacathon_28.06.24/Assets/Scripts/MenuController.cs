using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    public Animator loadingAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ButtonClick(int scene_number)
    {
        loadingAnimator.Play("LoadingAnimation");
        SceneManager.LoadScene(scene_number);
    }
}
