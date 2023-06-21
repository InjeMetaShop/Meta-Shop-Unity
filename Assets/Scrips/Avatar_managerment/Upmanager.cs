using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upmanager : MonoBehaviour
{
    // Start is called before the first frame update
    static Upmanager instance;
    public GameObject man2;
    public GameObject Capobject;
    public GameObject Upobject;
    public GameObject Downobject;
    public GameObject Setobjact;
    public GameObject shoseobjact;
    public GameObject earingobjact;

    GameObject object1;

    public static Upmanager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Upmanager>();
            return instance;
        }
    }

    public void setobject(string part, GameObject g)
    {
        if(part == "up"){
            Upobject =  g;
        }
        else if(part == "down")
        {
            Downobject = g;
        }
        else if (part == "cap")
        {
            Capobject = g;
        }
        else if(part == "set")
        {
            Setobjact = g;
        }
        else if (part == "shose")
        {
            Setobjact = g;
        }
        else if (part == "earing")
        {
            Setobjact = g;
        }
    }

    public GameObject getman()
    {
        return man2;
    }

    public void SDetroy(string part)
    {
        if (part == "up")
        {
            object1 = Upobject;
            Destroy(object1);
        }
        else if (part == "down")
        {
            Destroy(Downobject);
        }
        else if (part == "cap")
        {
            Destroy(Capobject);
        }
        else if (part == "set")
        {
            Destroy(Setobjact);
        }
        else if (part == "shose")
        {
            Destroy(shoseobjact);
        }
        else if (part == "earing")
        {
            Destroy(earingobjact);
        }
    }
}
