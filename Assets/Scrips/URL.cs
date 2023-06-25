using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
    public void GoogleURL()
    {
        try {
            Application.OpenURL("http://locallhost:3000/");
        }   catch {
            Application.OpenURL("http://192.168.0.183:3000/");
        }
    }
}
