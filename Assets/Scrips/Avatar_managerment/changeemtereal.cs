using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeemtereal : MonoBehaviour
{
    public int number;
    GameObject gObject;
    uo_button_cerate manager;
    string url = "Material/TOP_001_UV ";

    // Start is called before the first frame update
    void Start()
    {
        manager = uo_button_cerate.Instance;
        number = manager.getnember();
    }

    // Update is called once per frame
    public void ChangeMaterial()
    {
        gObject = manager.getup();
        gObject.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(url + number);
    }
}
