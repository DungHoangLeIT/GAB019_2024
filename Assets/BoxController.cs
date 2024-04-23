using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public BoxElement[] boxElements;
    private void Update()
    {
        boxElements = transform.GetComponentsInChildren<BoxElement>();
    }
}
