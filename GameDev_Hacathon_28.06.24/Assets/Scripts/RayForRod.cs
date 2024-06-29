using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForRod : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator RodCor(GameObject fish)
    {
        while (true)
        {
            transform.LookAt(fish.transform.position);
            yield return null;
        }
    }
}
