using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL_call : MonoBehaviour
{
    // Start is called before the first frame update
    public void Url_Call()
    {
        Application.OpenURL("http://192.168.0.183:3000/");
    }
}
