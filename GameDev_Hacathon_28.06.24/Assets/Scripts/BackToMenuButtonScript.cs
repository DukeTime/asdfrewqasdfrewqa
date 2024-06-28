using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButtonScript : MonoBehaviour
{

    public void ButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
