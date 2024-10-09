using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera PlayerCamera;

    private void Awake()
    {
        PlayerCamera = Camera.main;
    }

    void Update()
    {
        //transform.LookAt(PlayerCamera.transform);
        transform.rotation = PlayerCamera.transform.rotation;
    }
}
