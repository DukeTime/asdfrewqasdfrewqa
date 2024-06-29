using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Collection : MonoBehaviour
{
    [SerializeField] public GameObject myObject;

    void Start()
    {

        string objectName = myObject.name;
        Debug.Log(objectName);
        int is_opened = PlayerPrefs.GetInt(objectName);
        if (is_opened == 1){
            GetComponent<Image>().color = new Color(255/255.0f, 255/255.0f, 255/255.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}