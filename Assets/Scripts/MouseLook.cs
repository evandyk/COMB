using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float zMousePos;
    private float smoothedMousePos;

    private float currentLookingPos;

    private void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        RotatePlayer();
    }

    private void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        zMousePos = Input.GetAxisRaw("Mouse Z");
    }

    private void ModifyInput()
    {
        xMousePos *= sensitity * smoothing;
        zMousePos *= sensitity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    private void RotatePlayer()
    {
        currentLookingPos += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }
}
