using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upmanager : MonoBehaviour
{
    List<string> uplist = new List<string>();
    // Start is called before the first frame update
    public uo_button_cerate button;

    static Upmanager instance;

    public static Upmanager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Upmanager>();
            return instance;
        }
    }

    void Start()
    {
        uplist.Add("TOP_001_UV 1");
        uplist.Add("TOP_001_UV");
        
    }

    // Update is called once per frame
    public List<string> getUplist()
    {
        return uplist;
    }
}
