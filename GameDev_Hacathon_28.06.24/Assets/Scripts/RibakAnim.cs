using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibakAnim : MonoBehaviour
{
    [SerializeField] private GameObject idle;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject rod;

    public void RodAnim(int variant)
    {
        if (variant == 0)
        {
            idle.SetActive(true);
            right.SetActive(false);
            left.SetActive(false);
            rod.transform.position = new Vector3(1.307692f, 2.816667f, -5.5f);
        }
        else if (variant == 1)
        {
            idle.SetActive(false);
            right.SetActive(false);
            left.SetActive(true);
            rod.transform.position = new Vector3(-3.5f, 1.4f, -6);
        } 
        else if (variant == 2)
        {
            idle.SetActive(false);
            right.SetActive(true);
            left.SetActive(false);
            rod.transform.position = new Vector3(3.5f, 1.4f, -6);
        }
    }
}
