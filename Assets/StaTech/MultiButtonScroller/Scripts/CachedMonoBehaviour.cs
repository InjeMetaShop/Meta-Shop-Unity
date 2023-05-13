using UnityEngine;
using System.Collections;

public class CachedMonoBehaviour : MonoBehaviour {

	private RectTransform _rectT;

	public RectTransform RectT{
		get{
			if(_rectT == null){
				_rectT = this.GetComponent<RectTransform>();
				if(!_rectT)Debug.LogWarning("this is not UI object");
			}
			return _rectT;
		}
	}

	public RectTransform Initialize(Transform transform_ = null, bool worldPositionStays = false)
	{
		if (transform_ != null)
		{
			RectT.SetParent(transform_, worldPositionStays);
		}
		RectT.localScale = Vector3.one;
		RectT.anchoredPosition = Vector2.zero;
		return RectT;
	}

}
