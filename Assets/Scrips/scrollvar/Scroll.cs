using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scroll : MonoBehaviour
{
    string DROPDOWN_KEY = "DROPDOWN_KEY";

    int currentOption;
    
    TMP_Dropdown options;

    void Awake()
    {
        if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false) currentOption = 0;
        else currentOption = PlayerPrefs.GetInt(DROPDOWN_KEY);
    }

    void Start()
    {
        options = this.GetComponent<TMP_Dropdown>();

        options.value = currentOption;

        options.onValueChanged.AddListener(delegate { setDropDown(options.value); });
        setDropDown(currentOption); //최초 옵션 실행이 필요한 경우
    }

    void setDropDown(int option)
    {
        PlayerPrefs.SetInt(DROPDOWN_KEY, option);

        // option 관련 동작
        Debug.Log("current option : " + option);
    }

    public int getPlayerkey(){
        return options.value;
    }
}
