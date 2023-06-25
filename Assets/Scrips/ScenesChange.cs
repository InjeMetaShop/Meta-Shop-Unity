using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesChange : MonoBehaviour
{
    public void ScenesChange0()
    {
        // 씬 번호를 이용해서 씬 이동
        SceneManager.LoadScene(0);  // 0 번째 씬 로드
    }
    public void ScenesChange1()
    {
        // 씬 번호를 이용해서 씬 이동
        SceneManager.LoadScene(1);  // 0 번째 씬 로드
    }
}
