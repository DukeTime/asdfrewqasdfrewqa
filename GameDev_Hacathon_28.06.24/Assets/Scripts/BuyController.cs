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
        {"boat4", 700}
    };

    [SerializeField] public GameObject myObject;

    int price;
    void Start()
    {
        price = prices[this.gameObject.name];

        is_bought = PlayerPrefs.GetInt(this.gameObject.name);
        if (is_bought == 1){
            GetComponent<Image>().color = new Color(255/255.0f, 255/255.0f, 255/255.0f, 125/255.0f);
        }
    }

    public void BuyItem()
    {
        int balance = PlayerPrefs.GetInt("money");

        if (balance >= price & is_bought == 0){
        Debug.Log("bought" + this.gameObject.name);
        PlayerPrefs.SetInt(this.gameObject.name, 1);
        
        GetComponent<Image>().color = new Color(255/255.0f, 255/255.0f, 255/255.0f, 125/255.0f);

        SceneManager.LoadScene(3);

        PlayerPrefs.SetInt("money", balance - price);
        }
    }

    void Update()
    {
        
    }
}
