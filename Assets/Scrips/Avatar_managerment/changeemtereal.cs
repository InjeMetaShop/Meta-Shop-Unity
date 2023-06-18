using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeemtereal : MonoBehaviour
{
    public int number;
    GameObject gObject;
    GameObject gObject_sub;
    scrollView scrollview;
    static Upmanager instance;
    images images_sub;

    string parts;
    string url = "Image/";

    // Start is called before the first frame update
    void Start()
    {
        images_sub = gameObject.GetComponent<images>();
        instance = Upmanager.Instance;
    }

    public void setparts(string partsed)
    {
        url = "Image/";
        parts = partsed;
        url = url + parts + "/";
    }

    // Update is called once per frame
    public void ChangeMaterial()
    {
        number  = images_sub.getNumber();
        setparts(images_sub.getParts());
        gObject = Resources.Load<GameObject>(url + "prefab/" + number);

        instance.SDetroy(parts);
        gObject_sub = Instantiate(gObject, instance.getman().transform);

        instance.setobject(parts, gObject_sub);
        gObject_sub.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(url + "Materials/" + number);
    }
}
