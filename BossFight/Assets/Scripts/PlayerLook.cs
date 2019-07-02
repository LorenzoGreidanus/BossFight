using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;
    private float maxRotationUp;
    private float maxRotationDown;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
        maxRotationUp = 90f;
        maxRotationDown = -90f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > maxRotationUp)
        {
            xAxisClamp = maxRotationUp;
            mouseY = 0.0f;
            ClampXAxisRotation(270.0f);
        }
        else if (xAxisClamp < maxRotationDown)
        {
            xAxisClamp = maxRotationDown;
            mouseY = 0.0f;
            ClampXAxisRotation(maxRotationUp);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotation(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}