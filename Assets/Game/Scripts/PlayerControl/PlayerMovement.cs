using Game.Scripts.BattleScripts;
using UnityEngine;

namespace Game.Scripts.PlayerControl {
    [RequireComponent(typeof(Rigidbody2D), typeof(Shooter),
        typeof(AnimatorController))]
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private bool isGrounded = false;
        [SerializeField] private CircleCollider2D legsCircleCollider2D;
        [SerializeField] private float jumpOffset = 0.1f;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private AnimationCurve speedCurve;
        private Rigidbody2D rigidbody2D;
        private Shooter shooter;
        private AnimatorController animatorController;

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
            shooter = GetComponent<Shooter>();
            animatorController = GetComponent<AnimatorController>();
        }

        private void FixedUpdate() {
            Vector3 overlapCirclePosition = legsCircleCollider2D.bounds.center;
            float overlapRadius = legsCircleCollider2D.radius + jumpOffset;
            isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, overlapRadius, groundLayerMask);
        }

        public void MoveJumpAndShoot(float direction, bool isJumpButtonPressed, bool isShoot) {
            if (isJumpButtonPressed) {
                Jump();
            }
            if (Mathf.Abs(direction) > 0.01f) {
                HorizontalMovement(direction);
            }
            animatorController.Move(direction);
            shooter.ChangeDirection(direction);
            if (isShoot) {
                shooter.Shoot();
                animatorController.Attack();
            }
        }

        private void Jump() {
            if (isGrounded) {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                animatorController.Jump();
            }
        }

        private void HorizontalMovement(float direction) {
            rigidbody2D.velocity = new Vector2(speedCurve.Evaluate(direction), rigidbody2D.velocity.y);
        }
        void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Vector3 overlapCirclePosition = legsCircleCollider2D.bounds.center;
            float overlapRadius = legsCircleCollider2D.radius + jumpOffset;
            Gizmos.DrawWireSphere(overlapCirclePosition, overlapRadius);
        }
    }
}