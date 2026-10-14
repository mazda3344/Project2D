using UnityEngine;
namespace Game.Scripts.BattleScripts {
    public class Shooter : MonoBehaviour {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float fireSpeed = 20f;
        [SerializeField] private Transform leftShootPoint, rightShootPoint;
        private Transform lastShootPoint;
        private float lastShootDirection;

        private void Start() {
            ChangeDirection(1);
        }

        public void ChangeDirection(float direction) {
            if (Mathf.Abs(direction) > 0.01f) {
                if (direction > 0) {
                    lastShootPoint = rightShootPoint;
                    lastShootDirection = 1;
                } else {
                    lastShootPoint = leftShootPoint;
                    lastShootDirection = -1;
                }
            }
        }

        public void Shoot() {
            // Debug.Log("Shooter::Shoot(); -- ");
            GameObject currentBullet = Instantiate(bullet);
            currentBullet.tag = gameObject.tag;
            Rigidbody2D currentBulletRigidbody2D = currentBullet.GetComponent<Rigidbody2D>();
            currentBullet.transform.position = lastShootPoint.position;
            currentBulletRigidbody2D.velocity = new Vector2(fireSpeed * lastShootDirection, currentBulletRigidbody2D.velocity.y);
        }
    }
}