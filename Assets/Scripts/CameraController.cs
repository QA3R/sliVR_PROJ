using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float minVal = 90f;
    [SerializeField]
    private float maxVal = 90f;
    private float xRotation = 0f;
    private float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float verticalRotation = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= verticalRotation;
        xRotation = Mathf.Clamp(xRotation, minVal, maxVal);

        //transform.Translate(new Vector3(horizontalRotation, verticalRotation, 0));

        yRotation += horizontalRotation;
        yRotation = Mathf.Clamp(yRotation, minVal, maxVal);

        transform.localRotation = Quaternion.Euler (xRotation, yRotation, 0f);
    }
}
