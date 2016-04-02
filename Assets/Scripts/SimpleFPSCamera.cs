using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleFPSCamera : MonoBehaviour {
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;

    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    private bool rotationMode = false;
    private UITargetSlider lastSlider;

    void Update()
    {
        if (Input.GetMouseButton(0) && Application.isEditor)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        var slider = Raycast();

        if (slider != lastSlider)
        {
            if (lastSlider != null)
            {
                lastSlider.LostFocus();
                lastSlider = null;
            }

            if (slider != null)
            {
                slider.PrepareClick();
                lastSlider = slider;
            }
        }
    }

    private UITargetSlider Raycast()
    {
        if (graphicRaycaster == null)
            return null;

        //Create the PointerEventData with null for the EventSystem
        PointerEventData ped = new PointerEventData(null);
        //Set required parameters, in this case, mouse position
        ped.position = Input.mousePosition;
        //Create list to receive all results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast it
        graphicRaycaster.Raycast(ped, results);
        for (int i = 0; i < results.Count; i++)
        {
            UITargetSlider slider = results[i].gameObject.GetComponent<UITargetSlider>();

            if (slider != null)
                return slider;
        }

        return null;
    }
}
