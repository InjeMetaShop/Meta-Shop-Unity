using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public uo_button_cerate button;

    static Upmanager instance;

    public GameObject man2;
    public GameObject Upobject;
    public GameObject Downobject;
    public GameObject Capobject;
    public GameObject Setobjact;

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
            Debug.Log("성공");
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
            Debug.Log("Upobject" + Upobject);
            Debug.Log("object1"+object1);
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
    }
}
