using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuyController : MonoBehaviour
{
    int is_bought;

    	
    [SerializeField] private Dictionary<string, int> prices = new Dictionary<string, int>()
    {
        {"boat1", 100},
        {"boat2", 300},
        {"boat3", 500},
        {"boat4", 700},
        {"rod1", 100},
        {"rod2", 300},
        {"rod3", 500},
        {"rod4", 700}

    };

    [SerializeField] public GameObject Button;

    [SerializeField] public GameObject UpgradeText;

    [SerializeField] public GameObject Price;

    // string name_;

    // Debug.Log(Button.name);


    // if (Button.name == "BoatUpgradeButton"){
    //     name = "boatlvl";
    // }


    // if (Button.name == "RodUpgradeButton") {
    //     name = "rodlvl";
    // }

    // int currentlvl = PlayerPrefs.GetInt(name+"lvl") + 1;

    void Start()
    {
        
    }

    public void BuyItem()
    {
        int balance = PlayerPrefs.GetInt("money");


        Debug.Log("bought" + this.gameObject.name);
        
        
        

        SceneManager.LoadScene(3);


    }

    void Update()
    {
        
    }
}
