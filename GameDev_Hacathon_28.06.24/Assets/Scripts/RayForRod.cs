using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForRod : MonoBehaviour
{
    [SerializeField] private GameObject rffr;
    // Start is called before the first frame update
    void Start()
    {
        rffr.SetActive(false);
    }

    public void Disapear(bool cancel)
    {
        rffr.SetActive(cancel);
    }
    public IEnumerator RodCor(GameObject fish)
    {
        //yield return new WaitForSeconds(1.5f);
        while (true)
        {
            transform.LookAt(fish.transform.position);
            yield return null;
        }
    }
}