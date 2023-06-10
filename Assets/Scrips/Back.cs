using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class Back : MonoBehaviour
{
    string category;

    [System.Serializable]
    public class ProductData
    {
        public string id;
        public string name;
        public int price;
        public string imagePath;
        public string sex;
        public string category;
    }

    public void setcategory(string a){
        category = a;
    }

    string url;

    List<ProductData> users;

    private const string apiUrl = "http://localhost:8080/api/product/all";

    void Start()
    {
        category = "up";
        StartCoroutine(GetCategoryDataProcess());
    }

    public void GetCategoryData()
    {
        StartCoroutine(GetCategoryDataProcess());
    }

    IEnumerator GetCategoryDataProcess()
    {
        // GET 요청을 보낼 URL 생성
        string url = apiUrl;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // 요청 보내기
            yield return www.SendWebRequest();

            // 응답 처리
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("요청 성공!");

                // 응답 데이터 가져오기
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);

                // JSON 배열 데이터 역직렬화
                users = JsonConvert.DeserializeObject<List<ProductData>>(responseText);

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
