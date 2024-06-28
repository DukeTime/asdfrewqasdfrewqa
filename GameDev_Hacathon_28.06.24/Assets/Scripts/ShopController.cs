using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    


    public int money;
    
    [SerializeField] public GameObject myObject;

    Text myText;

    void Start()
    {
        myText = myObject.GetComponent<Text>();

        money = PlayerPrefs.GetInt("money");
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = money.ToString();
    }
}
