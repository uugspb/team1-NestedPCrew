using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class ActionPoint : MonoBehaviour {
	public float duration = 2;
	public Ease easing = Ease.Linear;

    [SerializeField]
	private UnityEvent onComplete;

    [SerializeField]
    private Image progressUI;

    [SerializeField]
    private Canvas canvas;

	Tweener doingTweener;

    [SerializeField]
    private GameObject[] unlockPoints;

    [SerializeField]
    private GameObject[] hightlights;

    [SerializeField]
    private GameObject[] activateList;

    [SerializeField]
    private GameObject[] deactivateList;

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
            LoadScene.Instance.HideAll();

            for (int i = 0; i < unlockPoints.Length; i++)
                unlockPoints[i].SetActive(true);

            for (int i = 0; i < hightlights.Length; i++)
                hightlights[i].SetActive(true);

            for (int i = 0; i < activateList.Length; i++)
                hightlights[i].SetActive(true);

            for (int i = 0; i < deactivateList.Length; i++)
                hightlights[i].SetActive(true);

        });

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
