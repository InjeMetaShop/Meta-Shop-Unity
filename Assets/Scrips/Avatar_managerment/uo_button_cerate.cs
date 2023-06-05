using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uo_button_cerate : MonoBehaviour
{
    private Upmanager manager; 
    int number = 0;
    public GameObject gObject;
    public Button button;
    private List<string> uplist;
    // Start is called before the first frame update
    static uo_button_cerate instance;

    public static uo_button_cerate Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<uo_button_cerate>();
            return instance;
        }
    }

    void Start()
    {
        manager = Upmanager.Instance;
        uplist = manager.getUplist();
    }

    public int getnember()
    {
        return number++;
    }

    public GameObject getup()
    {
        return gObject;
    }

    // Update is called once per frame

}
