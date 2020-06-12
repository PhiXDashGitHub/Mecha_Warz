using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIconAnimation : MonoBehaviour
{
    public Animation Attack1, Attack2;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack1.Play("Bump");
        }
        if (Input.GetMouseButton(1))
        {
            Attack2.Play("Bump");
        }
    }
}
