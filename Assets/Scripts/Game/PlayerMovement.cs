using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float transformSpeed;
    public float angularSpeed;
    public float transitionSpeed;

    public Animator animator;

    Vector3 direction;

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        direction = Vector3.ClampMagnitude(Vector3.right * xInput + Vector3.forward * yInput, 1);

        animator.SetFloat("Move", direction != Vector3.zero ? Mathf.Lerp(animator.GetFloat("Move"), 1, transitionSpeed * Time.deltaTime) : Mathf.Lerp(animator.GetFloat("Move"), 0, transitionSpeed * Time.deltaTime));
    }

    void FixedUpdate()
    {
        if (direction != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(direction, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, angularSpeed * Time.fixedDeltaTime);

            rigidbody.MovePosition(transform.position + transform.forward * transformSpeed * Time.fixedDeltaTime);
        }
    }
}
