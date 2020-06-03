using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform target;
    public BoxCollider2D bounds;

    public float lerpTime;

    void Update()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 2, bounds.size.y / 2);

        transform.position = Vector3.Slerp(transform.position, target.position, lerpTime * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, (-bounds.size.x / 2) + (Camera.main.orthographicSize * 16) / 9, (bounds.size.x / 2) - (Camera.main.orthographicSize * 16) / 9);
        pos.y = Mathf.Clamp(pos.y, -bounds.size.y / 2 + Camera.main.orthographicSize, bounds.size.y / 2 - Camera.main.orthographicSize);
        transform.position = pos;
    }
}
