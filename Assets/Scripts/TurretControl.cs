using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public static Vector3 mousePos;

    void Update()
    {
        //mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - new Vector3(Screen.width / 2, 0, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mousePos = Physics.Raycast(ray, out RaycastHit hit) ? hit.point : mousePos;
        mousePos.y = transform.position.y;

        transform.LookAt(mousePos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(mousePos, 0.5f);
    }
}
