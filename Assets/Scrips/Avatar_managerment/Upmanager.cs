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
    public GameObject shoesobjact;

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
        else if (part == "shoes")
        {
            shoesobjact = g;
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
        else if (part == "shoes")
        {
            Destroy(shoesobjact);
        }
    }

    public GameObject GetObject(string part)
    {
        if (part == "up")
        {
           return Upobject;
        }
        else if (part == "down")
        {
            return Downobject;
        }
        else if (part == "cap")
        {
            return Capobject;
        }
        else if (part == "set")
        {
            return Setobjact;
        }
        else if (part == "shoes")
        {
            return shoesobjact;
        }   
        else
            return null;
    }

    public void setbody(string parts)
    {
        if(parts == "set")
        {
            if(check_null_object("up"))
            {
                Upobject.SetActive(false);
            } 
            if(check_null_object("down"))
            {
                Downobject.SetActive(false);
            } 
            if(check_null_object("set"))
            {
                Setobjact.SetActive(true);
            } 
        }
        else if(parts == "up" || parts == "down")
        {
            if(check_null_object("up"))
            {
                Upobject.SetActive(true);
            } 
            if(check_null_object("down"))
            {
                Downobject.SetActive(true);
            } 
            if(check_null_object("set"))
            {
                Setobjact.SetActive(false);
            } 
        }
    }
    bool check_null_object(string part)
    {
        if(GetObject(part) == null)
        {
            return false;
        }
        else 
            return true;
    }
}
