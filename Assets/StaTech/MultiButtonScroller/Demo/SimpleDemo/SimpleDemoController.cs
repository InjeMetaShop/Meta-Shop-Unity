using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class SimpleDemoController : MonoBehaviour {

	[SerializeField]
	private MultiButtonScrollerSetting _setting;

	[SerializeField]
	private SimpleDemoButtonView _buttonViewOrigin;
    public Sprite chage_img;
    Image thisImg;
    List<SimpleDemoButtonData> dataList;

	void Start(){
		dataList = new List<SimpleDemoButtonData>();

		//Generate Data
		for(int i = 1; i <= 100; i++){
			dataList.Add(new SimpleDemoButtonData(){Content = "Clothes Photo" + i});
		}

		_setting.Initialize(_buttonViewOrigin,dataList.ToArray());
	}

    public void call()
    {
        _setting.Initialize(_buttonViewOrigin, dataList.ToArray());
        Debug.Log("call");
    }
    
}