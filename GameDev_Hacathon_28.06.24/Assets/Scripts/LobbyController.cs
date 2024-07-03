using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Text location_title;
    [SerializeField] private Text coin_title;
    private string[] locations = {"Pond", "Lake"};
    private int during_location = 0;

    private void Start()
    {
        
    }
    public void ChangeScene(int scene_num)
    {
        SceneManager.LoadScene(scene_num);
    }

    public void LocationChange(int change)
    {
        if (change > 0)
        {
            during_location += during_location != locations.Length - 1 ? 1 : 0;
            location_title.text = locations[during_location];

        }
        else
        {
            during_location -= during_location != 0 ? 1 : 0;
            location_title.text = locations[during_location];
        }
    }
}
