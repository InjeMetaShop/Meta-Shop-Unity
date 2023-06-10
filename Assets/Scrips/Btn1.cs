using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Btn1 : MonoBehaviour
{
    GameObject hhh;
    Human human;
    public static int fcount = 0;
    public static  int mcount = 0;
    public static  int sexcount = 0;
    public static GameObject[] avatar;
 
    private void initAvatarArr()
    {
        avatar = new GameObject[]{
            Resources.Load<GameObject>("Prefab/Underwear1")
        };
    }
    void start()
    {
        fcount = 0;
        mcount =0;
        sexcount = 0;
    }
    
   
    void Awake()
    {
        human = GameObject.Find("ARSessionOrigin").GetComponent<Human>();
    }

    public void female()
    {
        if (fcount == 1)
        {
            Destroy(human.Object);
            human.ChangePrefabTo("f3");

        }
        else if (fcount == 2)
        {
            Destroy(human.Object);
            human.ChangePrefabTo("f3");
        }
    
    }
    public void male()
    {
        if (mcount == 1)
        {
            Destroy(human.Object);
            human.ChangePrefabTo("m3");
        }
        else if (mcount == 2)
        {
            Destroy(human.Object);
            human.ChangePrefabTo("m3");
        }
    }
    public void OnHitLeft()
    {
        fcount = fcount - 1;
        mcount = mcount - 1;
        if (sexcount % 2 == 0)
        {
            female();
        }
        else
        {
            male();
        }
    }

    public void OnHuiRight()
    {
        
        fcount = fcount + 1;
        mcount = mcount + 1;
        Debug.Log(fcount);
        if (sexcount % 2 == 0)
        {
            female();
        }
        else
        {
            male();
        }
    }
    public void sexchange()
    {
        
        sexcount += 1;
    }
    
    public int getfcount()
    {
        return fcount;
    }
    public int getmcount()
    {
        return mcount;
    }
    public int getsexcount()
    {
        return sexcount;
    }
}
