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
        url = url + parts + "/" ;
    }

    // Update is called once per frame
    public void ChangeMaterial()
    {
        number  = images_sub.getNumber();
        setparts(images_sub.getParts());
        if(number == -1)
        {
            instance.SDetroy(parts);
            GameObject gmae = instance.GetObject(parts);
            gmae = null;
        }
        else
        {
            gObject = Resources.Load<GameObject>(url + "prefab/" + parts + "_" + number);

            instance.setbody(parts);
            if(instance.GetObject(parts) != null)
            {
                instance.SDetroy(parts);
            }
            gObject_sub = Instantiate(gObject, instance.getman().transform);

            instance.setobject(parts, gObject_sub);
            Debug.Log(url + "Materials/" + parts + "_" + number);
            try{
                gObject_sub.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(url + "Materials/" + parts + "_" + number);
            } catch{
                gObject_sub.GetComponent<MeshRenderer>().material = Resources.Load<Material>(url + "Materials/" + parts + "_" + number);
            }
        }
    }
}
