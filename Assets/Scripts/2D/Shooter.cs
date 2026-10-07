using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.PlayerControl;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint1, firePoint2;
    private Transform lastShootPoint;
    private float lastShootDirection;
    
    private AnimatorController animatorController;
    private void Awake()
    {
        animatorController = GetComponent<AnimatorController>();
    }

    private void Start() 
        {
            ChangeDirection(1);
        }

    public void ChangeDirection(float direction) 
    {
            if (Mathf.Abs(direction) > 0.01f) 
            {
                if (direction > 0) 
                {
                    lastShootPoint = firePoint1;
                    lastShootDirection = 1;
                } else 
                {
                    lastShootPoint = firePoint2;
                    lastShootDirection = -1;
                }
            }
    }

    public void Shoot() 
    {
        GameObject currentBullet = Instantiate(bullet);
        currentBullet.tag = gameObject.tag;
        Rigidbody2D currentBulletRigidbody2D = currentBullet.GetComponent<Rigidbody2D>();
        currentBullet.transform.position = lastShootPoint.position;
        currentBulletRigidbody2D.velocity = new Vector2(fireSpeed * lastShootDirection, currentBulletRigidbody2D.velocity.y);
        animatorController.Attack();
    }

    public void Shoot(float value)
    {
        Debug.Log("Shooter::Shoot(); -- value:" + value);
    }
}
