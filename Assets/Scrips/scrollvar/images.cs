using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class images : MonoBehaviour
{
    int number; 
    string parts;

    // Start is called before the first frame update
    public void setinit(int num, string part)
    {
        num = number;
        parts = part;
    }

    public int getNumber()
    {
        return number;
    }

    public string getParts()
    {
        return parts;
    }
}
