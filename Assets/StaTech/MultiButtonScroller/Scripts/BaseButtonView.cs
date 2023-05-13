using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// base class of button view
/// </summary>
[RequireComponent(typeof(Button))]
public abstract class BaseButtonView : CachedMonoBehaviour{

	public void Initialize(float width,float height,RectTransform root){
		if(!RectT)return;
		RectT.sizeDelta = new Vector2(width,height);
		RectT.SetParent(root);
		RectT.anchorMax = new Vector2(0,1);
		RectT.anchorMin = new Vector2(0,1);
		RectT.pivot = new Vector2(0,1);
		RectT.localScale = Vector2.one;
		RectT.gameObject.SetActive(true);
		RectT.localPosition = new Vector3(RectT.localPosition.x,RectT.localPosition.y,0f);
	}

	public abstract void SetData(BaseButtonData data);
}