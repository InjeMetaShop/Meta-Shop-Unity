using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceTrackingButton : MonoBehaviour
{
    GameObject aRFaceManager;
    private GameObject currentGameObject;
    public GameObject ARSessionOrigin;
    public GameObject ARSessionOrigin2;
    public GameObject ARSessionOriginNull;
    private void Awake()
    {
        
    }

    public void UpdateFaceMask(GameObject gameObject)
    {
        currentGameObject = gameObject;
        UpdateARFacePrefab();
    }

    public void UpdateFaceMask2(GameObject gameObject)
    {
        currentGameObject = gameObject;
        UpdateARFacePrefab2();
    }
    public void UpdateFaceNull(GameObject gameObject)
    {
        currentGameObject = gameObject;
        UpdateARFaceNull();
    }

    private void UpdateARFacePrefab()
    {
        Destroy(GameObject.FindWithTag("FaceMaskCamera"));
        Instantiate(ARSessionOrigin);
        aRFaceManager = GameObject.FindWithTag("FaceMaskCamera");
        aRFaceManager.GetComponent<ARFaceManager>().facePrefab = currentGameObject;
    }
    private void UpdateARFacePrefab2()
    {
        Destroy(GameObject.FindWithTag("FaceMaskCamera"));
        Instantiate(ARSessionOrigin2);
        aRFaceManager = GameObject.FindWithTag("FaceMaskCamera");
        aRFaceManager.GetComponent<ARFaceManager>().facePrefab = currentGameObject;
    }
      private void UpdateARFaceNull()
    {
        Destroy(GameObject.FindWithTag("FaceMaskCamera"));
        Instantiate(ARSessionOriginNull);
        aRFaceManager = GameObject.FindWithTag("FaceMaskCamera");
        aRFaceManager.GetComponent<ARFaceManager>().facePrefab = currentGameObject;
    }
}
