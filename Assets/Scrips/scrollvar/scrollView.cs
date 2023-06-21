using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollView : MonoBehaviour
{
    private ScrollRect scrollRect;

    public float space = 250f;
    float x = 50f;

    public GameObject uiPrefab;
    GameObject uiPrefab_sub;

    images image_sub;
    int number;

    public List<GameObject> uiObjects = new List<GameObject>();
    string  parts;

    void Start()
    {
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        number = 0;
    }

    public void ComponentClear()
    {
        for(int i=0; i< uiObjects.Count;i++){
            Destroy(uiObjects[i]);
        }
        number = 0;
    }


    public void AddNewUiObject()
    {
        uiPrefab_sub = Instantiate(uiPrefab, scrollRect.content);
        uiObjects.Add(uiPrefab_sub);
        var newUI = uiPrefab_sub.GetComponent<RectTransform>();

        x += space;
        newUI.anchoredPosition = new Vector2(x, 0f);
        scrollRect.content.sizeDelta = new Vector2(50f, scrollRect.content.sizeDelta.y);

        image_sub = uiPrefab_sub.GetComponent<images>();
        setimages(image_sub);
    }

    public void setParts(string part)
    {
        parts = part;
    }

    void setimages(images image_sub)
    {
        image_sub.setinit(number, parts);
        number++;
    }
}
