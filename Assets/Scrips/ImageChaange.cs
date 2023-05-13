using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChaange : MonoBehaviour
{
    public Sprite chage_img;
    Image thisImg;
    Btn1 btn;
    GameObject GameObJect;
    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
        btn = GetComponent<Btn1>();
        //int a = GameObJect.Find("RightButton").GetComponent<Btn1>().fcount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeImage(string ImageName)
    {
        chage_img = Resources.Load<Sprite>($"Image/{ImageName}");
        thisImg.sprite = chage_img;
        Debug.Log("ChangeImage");
        Debug.Log(chage_img);
    }

    public void OnButton()
    {
        btn = GetComponent<Btn1>();
        Debug.Log(btn.getfcount());
      
        if(btn.getfcount() == 0 && btn.getsexcount()%2 == 0)
        {
            Debug.Log("10");
            ChangeImage("maneking1");
        }
        else if(btn.getmcount() == 0 && btn.getsexcount() % 2 == 1)
        {
            Debug.Log("11");
            ChangeImage("maneking2");
        }
        else if (btn.getfcount() == 1 && btn.getsexcount() % 2 == 0)
        {
            Debug.Log("12");
            ChangeImage("dr1");
        }
        else if(btn.getfcount() == 2 && btn.getsexcount() % 2 == 0)
        {
            Debug.Log("13");
            ChangeImage("dr2");
        }
        else if (btn.getfcount() == 1 && btn.getsexcount() % 2 == 1)
        {
            Debug.Log("12");
            ChangeImage("dr3");
        }
        else if (btn.getfcount() == 2 && btn.getsexcount() % 2 == 1)
        {
            Debug.Log("13");
            ChangeImage("dr4");
        }
    }
        
}
