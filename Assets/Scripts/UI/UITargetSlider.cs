using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class UITargetSlider : MonoBehaviour {

	public float duration = 2;
	public Ease easing = Ease.Linear;
	public bool disableOnComplete = true;

	public UnityEvent onComplete;
	Image progressUI;
	Tweener doingTweener;

	void Start () {
		progressUI = this.gameObject.GetComponent<Image> ();
	}

	public void PrepareClick()
	{
		progressUI.enabled = true;
		progressUI.fillAmount = 0;
		doingTweener = DOTween.To(()=> progressUI.fillAmount, x=> progressUI.fillAmount = x, 1, duration).SetEase(easing).OnComplete(Completed);
	}

	public void LostFocus()
	{
		progressUI.enabled = false;
		doingTweener.Kill ();
	}

	public void Completed()
	{
		if (disableOnComplete)
			progressUI.enabled = false;
		onComplete.Invoke ();
	}
}
