using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesChange : MonoBehaviour
{
    public void ScenesChange0()
    {
        // �� ��ȣ�� �̿��ؼ� �� �̵�
        SceneManager.LoadScene(0);  // 0 ��° �� �ε�
    }
    public void ScenesChange1()
    {
        // �� ��ȣ�� �̿��ؼ� �� �̵�
        SceneManager.LoadScene(1);  // 0 ��° �� �ε�
    }
}
