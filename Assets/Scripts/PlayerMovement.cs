using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [Header("Sellings")]
    [SerializeField] private float speed;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector3 ovevlapCiclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(ovevlapCiclePosition, jumpOffset, groundMask);
    }
    public void Move(float direction, bool isJumpButtobPressed)
    {
        if (isJumpButtobPressed)
        Jump();

        if(direction != 0)
        HorizontalMovement(direction);
    }
    private void Jump()
    {
        if(isGrounded)
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * speed,rb.velocity.y);
    }
}
