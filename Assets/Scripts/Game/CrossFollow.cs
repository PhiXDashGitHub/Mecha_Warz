using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFollow : MonoBehaviour
{
    
    void Update()
    {
        transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<Animation>().Play();
        }
    }
}
