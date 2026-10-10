using UnityEngine;

namespace Game.Scripts.BattleScripts 
{
    public class Shooter : MonoBehaviour 
    {
        [Header("Prefabs & Physics")]
        [SerializeField] private GameObject bullet;
        [SerializeField] private float fireSpeed = 20f;

        [Header("Positions")]
        [SerializeField] private Transform leftShootPoint;
        [SerializeField] private Transform rightShootPoint;

        private Transform lastShootPoint;
        private float lastShootDirection;

        private void Start() 
        {
            ChangeDirection(1f);
        }

        public void ChangeDirection(float direction) 
        {
            if (Mathf.Approximately(direction, 0f)) return;

            if (direction > 0) 
            {
                lastShootPoint = rightShootPoint;
                lastShootDirection = 1f;
            } 
            else 
            {
                lastShootPoint = leftShootPoint;
                lastShootDirection = -1f;
            }
        }

        public void Shoot() 
        {
            if (bullet == null)
            {
                return;
            }
            if (lastShootPoint == null)
            {
                lastShootPoint = rightShootPoint != null ? rightShootPoint : transform;
                lastShootDirection = 1f;
            }
            GameObject currentBullet = Instantiate(bullet, lastShootPoint.position, Quaternion.identity);
            currentBullet.tag = gameObject.tag;
            if (currentBullet.TryGetComponent(out Rigidbody2D rb)) 
            {
                rb.velocity = new Vector2(fireSpeed * lastShootDirection, 0f);
            }
        }
    }
}
