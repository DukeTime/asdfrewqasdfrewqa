using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    


    private int money;
    public double mon;
    
    [SerializeField] public GameObject myObject;

    [SerializeField] public GameObject button;

    Text myText;
    public string type;
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
    public void ButtonClckType(string typ){
        type = typ;
    }
    public void ButtonClick(int lvl)
    {
        money = PlayerPrefs.GetInt("money");
        if (money >= 100){
            PlayerPrefs.SetInt(type, lvl);
            money = money - 100;
            PlayerPrefs.SetInt("money",money);
        }
        
    }
}
