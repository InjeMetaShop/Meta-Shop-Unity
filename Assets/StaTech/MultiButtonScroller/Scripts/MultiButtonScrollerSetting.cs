using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class MultiButtonScrollerSetting : MonoBehaviour {

	[SerializeField,Header("1.Set target root canvas")]
	private Canvas _rootCanvas;

	[SerializeField,Header("2.Set background image RectTransform")]
	private RectTransform _bgRectT;

		
	[SerializeField,Header("3.Set previous and next buttons.")]
	private Button _previousButton;
	[SerializeField]
	private Button _nextButton;

	//sidePaddingRateは0~0.5
	[SerializeField,Range(0f,0.5f),Header("4.Adjust button size")]
	private float _sidePaddingRate;

	[SerializeField,Range(0f,0.5f)]
	private float _upDownPaddingRate;

	//ボタンに対しての隙間の比率
	[SerializeField,Range(0f,1f)]
	private float _buttonPaddingXRate;

	[SerializeField,Range(0f,1f)]
	private float _buttonPaddingYRate;

	[SerializeField]
	private int _buttonRowsCount;
	[SerializeField]
	private int _buttonColumnCount;

	[SerializeField,Header("5.Set transition easing type, and duration")]
	private Ease _easingType;
	[SerializeField]
	private float _duration = 1f;

	[Header("*Activate preview")]
	public bool ShowPreview;

	private BaseButtonView _stageButtonOrigin;
	private SelectButtonGroup _currentButtonGroup;
	private SelectButtonGroup _nextButtonGroup;

	private int _currentPageIndex;
	private int _buttonCountPerPage;
	private int _pageCount;
	private int _maxButtonCount;

	private bool _isTweening = false;

	private BaseButtonData[] _selectButtonData;

	#region MonoBehaviour

	public void Initialize(BaseButtonView button,BaseButtonData[] datas){
		_selectButtonData = datas;
		_stageButtonOrigin = button;
		_previousButton.onClick.AddListener(SlideToPrevious);
		_nextButton.onClick.AddListener(SlideToNext);
		InitializeStageSelectUI();
	}

	#endregion

	#if UNITY_EDITOR
	void OnGUI(){
		if(Application.isPlaying) return;
		if(!ShowPreview) return;
		if(!_rootCanvas) return;
		var info = GenerateGroupInfo();

		for(int i = 0; i < info.ColumnCount; i++){
			for(int j = 0; j < info.RowsCount; j++){
				Vector3 screenPos =  RectTransformUtility.WorldToScreenPoint((_rootCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main),info.BaseRectT.position);
				var rectPosition = new Vector2(screenPos.x + j * (info.PaddingX + info.ButtonWidth) - info.RootRect.size.x/2f + info.SidePadding, -screenPos.y + Screen.height +(i * (info.PaddingY + info.ButtonHeight) - info.RootRect.size.y/2f + info.UpdownPadding));
				var size = new Vector2(info.ButtonWidth,info.ButtonHeight);
				Rect targetRect = new Rect(rectPosition,size);
				GUI.TextField(targetRect,"");
			}
		}
	}
	#endif

	#region PublicMethods
	public ButtonGroupInfo GenerateGroupInfo(){
		var width = _bgRectT.rect.size.x;
		var height = _bgRectT.rect.size.y;

		var sidePadding = width * _sidePaddingRate;
		var upDownPadding = height * _upDownPaddingRate;

		//ボタン配置部分のサイズ
		var contentWidth = width - sidePadding * 2;
		var contentHeight = height - upDownPadding * 2;

		var buttonWidth = contentWidth * (1/(_buttonRowsCount + (_buttonRowsCount - 1) * _buttonPaddingXRate));
		var paddingX = buttonWidth * _buttonPaddingXRate;

		var buttonHeight = contentHeight * (1/(_buttonColumnCount + (_buttonColumnCount - 1) * _buttonPaddingYRate));
		var paddingY = buttonHeight * _buttonPaddingYRate;

		if(Application.isPlaying){
			_maxButtonCount = _selectButtonData.Length;
		}else{
			_maxButtonCount = _buttonColumnCount * _buttonRowsCount;
		}

		ButtonGroupInfo groupInfo = new ButtonGroupInfo(){
			ButtonOrigin = _stageButtonOrigin,
			BasePoint = new Vector2(sidePadding,upDownPadding),
			ButtonWidth = buttonWidth,
			ButtonHeight = buttonHeight,
			PaddingX = paddingX,
			PaddingY = paddingY,
			SidePadding = sidePadding,
			UpdownPadding = upDownPadding,
			ColumnCount = _buttonColumnCount,
			RowsCount = _buttonRowsCount,
			MaxButtonCount = _maxButtonCount,
			RootRect = _bgRectT.rect,
			BaseRectT = _bgRectT,
		};
		return groupInfo;
	}

	#endregion

	#region PrivateMethods

	private void InitializeStageSelectUI(){
		if(Application.isPlaying){
			ReleaseForPlayMode();
		}

		var groupInfo = GenerateGroupInfo();

		_buttonCountPerPage = _buttonColumnCount * _buttonRowsCount;

		if(_buttonCountPerPage <= 0){
			Debug.Log("button count is something wrong");
		}
		_pageCount = Mathf.CeilToInt((float)_maxButtonCount / (float)_buttonCountPerPage);

		_currentButtonGroup = Load("SelectButtonGroup");
		_nextButtonGroup = Load("SelectButtonGroup");
		if(!_currentButtonGroup || !_nextButtonGroup){
			Debug.LogError("component load failed. stopped initializing SelectUI");
			return;
		}

		_currentButtonGroup.Initialize(_bgRectT.transform);
		_currentButtonGroup.Initialize(groupInfo,true);
		_currentButtonGroup.RefreshView(1,_buttonCountPerPage,_selectButtonData);

		_nextButtonGroup.Initialize(_bgRectT.transform);
		_nextButtonGroup.Initialize(groupInfo,false);

		RefreshArrow();
	}

	private SelectButtonGroup Load(string path){
		var loadedObj = Resources.Load(path) as GameObject;
		if(loadedObj){
			var instance = GameObject.Instantiate(loadedObj);
			return instance.GetComponent<SelectButtonGroup>();
		}
		return null;
	}

	private void ReleaseForPlayMode(){
		ReleaseButtonGroup(ref _currentButtonGroup);
		ReleaseButtonGroup(ref _nextButtonGroup);
	}

	private void ReleaseButtonGroup(ref SelectButtonGroup group){
		if(group == null) return;
		GameObject.Destroy(group.gameObject);
		group = null;
	}

	private void SlideToNext(){
		if(_currentPageIndex >= _pageCount|| _isTweening) return;
		_currentPageIndex++;
		Slide(SlideDirection.Left);
	}

	private void SlideToPrevious(){
		if(_currentPageIndex <= 0 || _isTweening) return;
		_currentPageIndex--;	
		Slide(SlideDirection.Right);
	}

	private void RefreshArrow(){
		_previousButton.gameObject.SetActive(_currentPageIndex > 0);
		_nextButton.gameObject.SetActive(_currentPageIndex < _pageCount - 1);
	}

	private void Slide(SlideDirection dir){
		int startIndex = _buttonCountPerPage * (_currentPageIndex) + 1;
		_nextButtonGroup.RefreshView(startIndex,_buttonCountPerPage,_selectButtonData);
		_nextButtonGroup.SetNextStartPosition(dir);

		_isTweening = true;
		_nextButtonGroup.Move(dir,_duration,_easingType,()=>{
			_isTweening = false;
			var temp = _currentButtonGroup;
			_currentButtonGroup = _nextButtonGroup;
			_nextButtonGroup = temp;
			_nextButtonGroup.gameObject.SetActive(false);
		});
		_currentButtonGroup.Move(dir,_duration,_easingType);
		RefreshArrow();
	}

	#endregion
}