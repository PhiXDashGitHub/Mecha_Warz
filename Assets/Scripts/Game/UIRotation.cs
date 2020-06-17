using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotation : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform, Camera.main.transform.up);
    }
}
