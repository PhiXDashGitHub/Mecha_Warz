using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public static Vector3 mousePos;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mousePos = Physics.Raycast(ray, out RaycastHit hit) ? hit.point : mousePos;
        mousePos.y = transform.position.y;

        transform.LookAt(mousePos);
    }
}
