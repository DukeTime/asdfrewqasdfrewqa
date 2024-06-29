using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    


    public int money;
    public double mon;
    
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
        if (money < 10000)
        {
            myText.text = money.ToString();
        }
        else if (money > 9999 && money < 100000)
        {
            float mon = money/1000;
            myText.text = mon.ToString() + "k";
        }
    }
}