using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public BoxCollider2D bounds;
    public float speed;

    Vector3 direction;

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        direction = Vector3.ClampMagnitude(Vector3.right * xInput + Vector3.up * yInput, 1);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -bounds.size.x / 2 + 0.5f, bounds.size.x / 2 - 0.5f);
        pos.y = Mathf.Clamp(pos.y, -bounds.size.y / 2 + 0.5f, bounds.size.y / 2 - 0.5f);
        transform.position = pos;
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
}
