using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class null_change : MonoBehaviour
{
    Upmanager instance;
    void Start() {
        instance = Upmanager.Instance;
        ClearAvater();
    }
    // Start is called before the first frame update
    public void ClearAvater()
    {
        instance.SDetroy("up");
        instance.SDetroy("down");
        instance.SDetroy("cap");
        instance.SDetroy("set");
        instance.SDetroy("shoes");
        
        instance.Upobject = null;
        instance.Downobject = null;
        instance.Setobjact = null;
        instance.shoesobjact = null;
        instance.Capobject = null;
    }
}
