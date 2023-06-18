using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scroll_view_change : MonoBehaviour
{
    int page;

    public Back back;

    public class ProductData
    {
        public string id;
        public string name;
        public int price;
        public string imagePath;
        public string sex;
        public string category;
    }

    Scroll scroll;
    List<string> page_name = new List<string>();
    List<ProductData> productdata;

    scrollView view;
    ScrollRect scrollRect;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        view = scrollRect.content.GetComponent<scrollView>();
        page = -1;
        page_name.Add("up");
        page_name.Add("down");
    }

    public void PageChange(Scroll objects)
    {

        scroll = objects.GetComponent<Scroll>();
        page = scroll.getPlayerkey();               // 언디가

        back.setcategory(page_name[page]);
        back.GetCategoryData();

        view.setParts(page_name[page-1]);
        for(int i=0; i < back.getProductDataSize(); i++){
            view.AddNewUiObject();
        } 
    }
}
