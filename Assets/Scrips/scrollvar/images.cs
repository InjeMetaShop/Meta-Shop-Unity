using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class images : MonoBehaviour
{
    int number; 
    string parts;
    Texture image;

    // Start is called before the first frame update
    public void setinit(int num, string part, string imagepath)
    {
        number = num;
        parts = part;
        if(part == "up" || part == "down")
        {
            image = Resources.Load<Texture>(imagepath);
            gameObject.GetComponent<RawImage>().texture = image;
        } else{
            StartCoroutine(GetTexture(imagepath));
        }
    }

    public void setnull(string part)
    {
        number = -1;
        parts = part;
        image = Resources.Load<Texture>("Image/null");
        gameObject.GetComponent<RawImage>().texture = image;
    }


    public int getNumber()
    {
        return number;
    }

    public string getParts()
    {
        return parts;
    }

    IEnumerator GetTexture(string url)
    {
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            image = ((DownloadHandlerTexture)www.downloadHandler).texture;
            gameObject.GetComponent<RawImage>().texture = image;
        }
    }
}

