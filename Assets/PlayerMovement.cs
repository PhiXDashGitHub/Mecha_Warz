using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float speed;

    Vector3 direction;

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        direction = Vector3.ClampMagnitude(Vector3.right * xInput + Vector3.up * yInput, 1);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
}
