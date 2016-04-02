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
    private ActionPoint lastSlider;

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

    private ActionPoint Raycast()
    {
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            //suppose i have two objects here named obj1 and obj2.. how do i select obj1 to be transformed 
            if (hit.transform != null)
            {
                return hit.transform.GetComponentInChildren<ActionPoint>();
            }
        }
        return null;
    }
}
