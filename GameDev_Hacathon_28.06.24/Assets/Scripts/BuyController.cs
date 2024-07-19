using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuyController : MonoBehaviour
{


    	


    [SerializeField] public GameObject Button;

    [SerializeField] public Image Image;

    [SerializeField] public Text UpgradeText;

    [SerializeField] public GameObject Price;

    [SerializeField] public Sprite lvl1;

    [SerializeField] public Sprite lvl2;

    [SerializeField] public Sprite lvl3;

    [SerializeField] public Sprite lvl4;


    int currentlvl;
    string name;

    void Start()
    {



    if (Button.name == "BoatUpgradeButton"){
        name = "boatlvl";
    }


    if (Button.name == "RodUpgradeButton") {
        name = "rodlvl";
    }

    Debug.Log(name);
    currentlvl = PlayerPrefs.GetInt(name+"lvl") + 1;
    Debug.Log(currentlvl);


    if (currentlvl == 1){
       Image.sprite = lvl1;
        UpgradeText.text = "Upgrade boat to level 2";
    }

    if (currentlvl == 2){
       Image.sprite = lvl2;
        UpgradeText.text = "Upgrade boat to level 3";
    }

    if (currentlvl == 2){
       Image.sprite = lvl2;
        UpgradeText.text = "Upgrade boat to level 4";
    }

    if (currentlvl == 2){
       Image.sprite = lvl2;
        UpgradeText.text = "Completely upgraded";
    }




    }

    public void BuyItem()
    {
        int balance = PlayerPrefs.GetInt("money");


        
        if (currentlvl < 4 & balance >= (currentlvl*200 + 100)){


            PlayerPrefs.SetInt(name+"lvl",currentlvl);

        }
        
        
        Debug.Log(currentlvl);
        SceneManager.LoadScene(3);


    }

    void Update()
    {
        
    }
}
