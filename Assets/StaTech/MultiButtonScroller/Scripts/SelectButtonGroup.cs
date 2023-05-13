using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using DG.Tweening;


[System.Serializable]
public class ButtonGroupInfo{
	public BaseButtonView ButtonOrigin;
	public Vector2 BasePoint;
	public float ButtonWidth;
	public float ButtonHeight;
	public float PaddingX;
	public float PaddingY;
	public float SidePadding;
	public float UpdownPadding;

	public int ColumnCount;
	public int RowsCount;
	public int MaxButtonCount;
	public Rect RootRect;
	public RectTransform BaseRectT;
}

public enum SlideDirection{
	Left,
	Right,
	Up,
	Down,
}

public class SelectButtonGroup : CachedMonoBehaviour {



	private List<BaseButtonView> _buttons = new List<BaseButtonView>();
	private ButtonGroupInfo _info;

	public void Initialize(ButtonGroupInfo info,bool visible){
		_info = info;
		CreateButtons(_info.ColumnCount,_info.RowsCount);
		gameObject.SetActive(visible);
	}

	public void CreateButtons(int columns,int rows){
		for(int i = 0; i < columns; i++){
			for(int j = 0; j < rows; j++){
				var button = CreateButton(_info.ButtonWidth,_info.ButtonHeight);
				button.RectT.anchoredPosition = new Vector2(_info.BasePoint.x + j * (_info.PaddingX +_info.ButtonWidth),-_info.BasePoint.y - i * (_info.PaddingY + _info.ButtonHeight));
				_buttons.Add(button);
			}
		}
	}

	private BaseButtonView CreateButton(float width,float height){
		if(_info.ButtonOrigin){
			BaseButtonView tempButton = GameObject.Instantiate(_info.ButtonOrigin);
			tempButton.Initialize(width,height,RectT);
			return tempButton;
		}
		return null;
	}

	public void Move(SlideDirection dir,float duration,Ease easingType = Ease.Linear,UnityAction callback = null){
		gameObject.SetActive(true);
		var endValueDiff = GetTweenEndValue(dir);
		var endValue = new Vector2(RectT.anchoredPosition.x + endValueDiff.x,RectT.anchoredPosition.y + endValueDiff.y);
		RectT.DOAnchorPos(endValue,duration).SetEase(easingType).OnComplete(()=>{
			if(callback != null) callback();
		});
	}

	public void SetNextStartPosition(SlideDirection dir){
		switch(dir){
		case SlideDirection.Down:
			RectT.anchoredPosition = new Vector2(0f,_info.RootRect.height);
			break;
		case SlideDirection.Up:
			RectT.anchoredPosition = new Vector2(0f,-_info.RootRect.height);
			break;
		case SlideDirection.Left:
			RectT.anchoredPosition = new Vector2(_info.RootRect.width,0f);
			break;
		case SlideDirection.Right:
			RectT.anchoredPosition = new Vector2(-_info.RootRect.width,0f);
			break;
		}
		gameObject.SetActive(true);
	}

	private Vector2 GetTweenEndValue(SlideDirection dir){
		switch(dir){
		case SlideDirection.Down:
			return new Vector2(0f,-_info.RootRect.height);
		case SlideDirection.Up:
			return new Vector2(0f,_info.RootRect.height);
		case SlideDirection.Right:
			return new Vector2(_info.RootRect.width,0f);
		case SlideDirection.Left:
			return new Vector2(-_info.RootRect.width,0f);
		}
		return Vector2.zero;
	}

	public void RefreshView(int start,int count,BaseButtonData[] buttonInfoList){
		var targetList = buttonInfoList.Skip(start - 1).Take(count).ToList();
		RefreshView(targetList);
	}

	public void RefreshView(List<BaseButtonData> buttonInfoList){
		if(buttonInfoList == null || buttonInfoList.Count == 0){
			Debug.Log("button info is null");
			return;
		}

		var buttonInfoCount = buttonInfoList.Count;
		var buttonCount = _buttons.Count;

		for(int i = 0; i < buttonCount; i++){
			if(i >= buttonInfoCount){
				_buttons[i].gameObject.SetActive(false);
			}else{
				_buttons[i].gameObject.SetActive(true);
				_buttons[i].SetData(buttonInfoList[i]);
			}
		}
	}
}