using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed;

    Vector3 direction;

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        direction = Vector3.ClampMagnitude(Vector3.right * xInput + Vector3.forward * yInput, 1);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
}
