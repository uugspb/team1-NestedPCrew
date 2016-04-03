using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Hackathon;

public class TimeIndicator : TimeBehaviour
{
    [SerializeField]
    private Slider slider;	
	// Update is called once per frame

    void Start()
    {
        var puppeteer = FindObjectOfType<Puppeteer>();
        slider.maxValue = puppeteer.lifetime;
    }
	void Update () {
        slider.value = timeline.time;
	}
}
