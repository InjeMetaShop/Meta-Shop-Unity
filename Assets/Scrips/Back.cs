using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class Back : MonoBehaviour
{
    string category;
    scroll_view_change view;

    [System.Serializable]
    public class ProductData
    {
        public string id;
        public string name;
        public int price;
        public string imagePath;
        public string fbxPath;
        public string sex;
        public string category;
    }

    public void setcategory(string a){
        category = a;
    }

    List<ProductData> users;

    private const string apiUrl = "http://localhost:8080/api/product/category/";  // 192.168.0.29

    public void GetCategoryData(scroll_view_change view_sub)
    {
        StartCoroutine(GetCategoryDataProcess());
        view = view_sub;
    }

    IEnumerator GetCategoryDataProcess()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl + category))
        {
            // 요청 보내기
            yield return www.SendWebRequest();

            // 응답 처리
            if (www.result == UnityWebRequest.Result.Success)
            {
                // 응답 데이터 가져오기
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);

                // JSON 배열 데이터 역직렬화
                users = JsonConvert.DeserializeObject<List<ProductData>>(responseText);
                
                view.CereatImage();
            }
            else
            {
                Debug.LogError("요청 실패: " + www.error);
            }
        }
    }

    public int getProductDataSize(){
        return users.Count;
    }
}
