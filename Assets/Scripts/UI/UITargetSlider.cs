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
	
    [SerializeField]
    private Image progressUI;
	Tweener doingTweener;
    
	public void PrepareClick()
	{
		progressUI.fillAmount = 0;
		doingTweener = DOTween.To(()=> progressUI.fillAmount, x=> progressUI.fillAmount = x, 1, duration).SetEase(easing).OnComplete(Completed);
	}

    public void MoveTo()
    {
        Camera.main.transform.position = this.transform.position;
    }

	public void LostFocus()
	{
        progressUI.fillAmount = 0;
		doingTweener.Kill ();
	}

	public void Completed()
	{
		if (disableOnComplete)
			progressUI.enabled = false;
		onComplete.Invoke ();
	}
}
