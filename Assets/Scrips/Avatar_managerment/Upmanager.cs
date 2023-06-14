using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public uo_button_cerate button;

    static Upmanager instance;

    public GameObject Upobject;
    public GameObject Downobject;
    public GameObject Capobject;
    public GameObject Setobjact;

    public static Upmanager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Upmanager>();
            return instance;
        }
    }

    public GameObject getobject(string part)
    {
        if(part == "up"){
            return Upobject;
        }
        else if(part == "down")
        {
            return Downobject;
        }
        else if (part == "cap")
        {
            return Capobject;
        }
        else if(part == "set")
        {
            return Setobjact;
        }
        return Upobject;
    }
}
