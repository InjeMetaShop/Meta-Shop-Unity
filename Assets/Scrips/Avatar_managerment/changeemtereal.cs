using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeemtereal : MonoBehaviour
{
    public int number;
    GameObject gObject;
    scrollView scrollview;
    Upmanager manager;
    images images_sub;

    string parts;
    string url = "Material/";

    // Start is called before the first frame update
    void Start()
    {
        images images_sub = gameObject.GetComponent<images>();
    }


    public void setparts(string partsed)
    {
        parts = partsed;
        url = url + parts + "/";
    }
    // Update is called once per frame
    public void ChangeMaterial()
    {
        number  = images_sub.getNumber();
        gObject = manager.getobject(parts);
        gObject.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(url + number);
    }
}
