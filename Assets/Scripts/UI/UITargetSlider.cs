using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class UITargetSlider : MonoBehaviour {

	public float duration = 2;
	public Ease easing = Ease.Linear;

    [SerializeField]
	private UnityEvent onComplete;

    [SerializeField]
    private UnityEvent afterMove;

    [SerializeField]
    private Image progressUI;

    [SerializeField]
    private Canvas canvas;

	Tweener doingTweener;
    
	public void PrepareClick()
	{
        canvas.transform.LookAt(Camera.main.transform.position);
        canvas.transform.RotateAround(Vector3.up, Mathf.PI);
		progressUI.fillAmount = 0;
		doingTweener = DOTween.To(()=> progressUI.fillAmount, x=> progressUI.fillAmount = x, 1, duration).SetEase(easing).OnComplete(Completed);
	}

    public void MoveTo()
    {
        Camera.main.transform.parent.DOMove(transform.position, 1f).OnComplete(() => {
            if(afterMove != null)
                afterMove.Invoke();
        });

        //StartCoroutine(MoveTo(transform.position, 1f));
    }
    private IEnumerator MoveTo(Vector3 pos, float length)
    {
        float startTime = Time.time;
        float fraction = 0f;
        
        Transform motionRoot = Camera.main.transform.parent;
        Vector3 startPosition = motionRoot.position;

        while (fraction < 1f)
        {
            fraction = Time.time - startTime / length;
            motionRoot.position = Vector3.Lerp(startPosition, pos, fraction);
            yield return null;
        }
    }

	public void LostFocus()
	{
        progressUI.fillAmount = 0;
		doingTweener.Kill();
	}

	public void Completed()
	{
		onComplete.Invoke();
	}
}
