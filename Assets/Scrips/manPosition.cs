using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manPosition : MonoBehaviour
{
    public GameObject indicator;

    void Update()
    {   
        gameObject.transform.position = indicator.transform.position;
    }
}
