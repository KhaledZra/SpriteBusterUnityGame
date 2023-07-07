using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCapHandler : MonoBehaviour
{
    [SerializeField] private int frameRateCap;

    private void Start()
    {
        Application.targetFrameRate = frameRateCap;
    }
}
