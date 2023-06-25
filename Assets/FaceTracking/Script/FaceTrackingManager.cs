using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceTrackingManager : MonoBehaviour
{
    public List<GameObject> mask = new List<GameObject>();
    public GameObject arSessionOrigin;
    int maskNumber;

    // Start is called before the first frame update
    void Start()
    {
      maskNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // //maskNumber = manager.GetComponent<FaceTracking>().GetMaskNumber();
        // Debug.Log(maskNumber);

        // if(maskNumber == 1)
        // {
            
        // }
        // else if(maskNumber == 2)
        // {
            
        // }
    }
    public void ChangeMask1()
    {
        arSessionOrigin.GetComponent<ARFaceManager>().facePrefab = mask[0];
        arSessionOrigin.SetActive(false);
        arSessionOrigin.SetActive(true);
    }
    public void ChangeMask2()
    {
        arSessionOrigin.GetComponent<ARFaceManager>().facePrefab = mask[1];
        arSessionOrigin.SetActive(false);
        arSessionOrigin.SetActive(true);
        
    }
}
