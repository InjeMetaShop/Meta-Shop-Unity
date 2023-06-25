using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceTracking : MonoBehaviour
{
    public GameObject arSessionOrigin;
    GameObject mask;
    GameObject manager;

    int maskNumber;
   
    // Start is called before the first frame update
    void Start()
    {
        maskNumber = 0;
        manager = GameObject.Find("FaceTrackingManager");
        arSessionOrigin = GameObject.Find("AR Session Origin");
        mask = GameObject.Find("FaceTrackingManager");
        
    }
    // Update is called once per frame
    void Update()
    {  
        //maskNumber = manager.GetComponent<FaceTracking>().GetMaskNumber();
        Debug.Log(maskNumber);
        if(maskNumber == 1)
        {
            
        }
        else if(maskNumber == 2)
        {
           
        }
    }
   
    
}
