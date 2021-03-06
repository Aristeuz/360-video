﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    public GameObject cameraContainer;
    private Quaternion rotation;

    private void Start()
    {
        cameraContainer.transform.position = transform.position;

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }
    
    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotation;
        }
    }
    
}
