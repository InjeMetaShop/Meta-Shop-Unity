using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollView : MonoBehaviour
{
    private ScrollRect scrollRect;

    public float space = 250f;
    float x = 50f;

    public RawImage uiPrefab;
    RawImage uiPrefab_sub;

    images image_sub;
    int number;

    public List<RawImage> uiObjects = new List<RawImage>();
    string  parts;

    void Start()
    {
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
    }

    public void ComponentClear()
    {
        Debug.Log("ui의 갯수는 " + uiObjects.Count);
        for(int i=0; i< uiObjects.Count;i++){
            Destroy(uiObjects[i]);
        }
    }


    public void AddNewUiObject()
    {
        uiPrefab_sub = Instantiate(uiPrefab, scrollRect.content);
        uiObjects.Add(uiPrefab_sub);
        var newUI = uiPrefab_sub.GetComponent<RectTransform>();
        number = uiObjects.IndexOf(uiPrefab_sub);

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
    }
}
