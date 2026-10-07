using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.PlayerControl;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D), typeof(Shooter),
        typeof(AnimatorController))]
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
    private AnimatorController animatorController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<AnimatorController>();
    }
    private void FixedUpdate()
    {
        Vector3 ovevlapCiclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(ovevlapCiclePosition, jumpOffset, groundMask);
    }
    public void Move(float direction, bool isJumpButtobPressed)
    {
        if (isJumpButtobPressed)
        {
        
            Jump();
        }

        if(Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
        }
        animatorController.Move(direction);
    }
    private void Jump()
    {
        if(isGrounded)
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animatorController.Jump();
    }
    public void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
    }
}
