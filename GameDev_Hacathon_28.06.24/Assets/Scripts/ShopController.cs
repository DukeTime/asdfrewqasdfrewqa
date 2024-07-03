using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    


    private int money;

    
    [SerializeField] public Text myObject;



    Text myText;
    public string type;
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        myObject.text = money.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

}
