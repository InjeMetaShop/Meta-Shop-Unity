using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scroll_view_change : MonoBehaviour
{
    int page;
    Scroll scroll;
    List<string> page_name = new List<string>();

    string url = "Image/up";

    // Start is called before the first frame update
    void Start()
    {
        page = -1;
        page_name.Add("up");
        page_name.Add("down");
    }

    public void PageChange(Scroll objects)
    {
        scroll = objects.GetComponent<Scroll>();
        string url2 = url + page_name[scroll.getPlayerkey()];
        
    }
}
