using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_music_BG : MonoBehaviour
{
    //this should be the name of your class
    [SerializeField] private AudioSource source;
    private static Play_music_BG instance;

    private void Awake()
    {
        source.mute = false;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
