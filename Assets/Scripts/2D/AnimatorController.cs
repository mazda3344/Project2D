using UnityEngine;
namespace Game.Scripts.PlayerControl {
    [RequireComponent(typeof(Animator),
        typeof(SpriteRenderer))]
    public class AnimatorController : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsDead = Animator.StringToHash("isDead");
        private static readonly int IsJump = Animator.StringToHash("isJump");
        // private float lastDirection;

        private void Start() {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(float direction) {
            if (Mathf.Abs(direction) < 0.01f) {
                animator.SetBool(IsRunning, false);
            } else {
                animator.SetBool(IsRunning, true);
                if (direction >= 0) {
                    spriteRenderer.flipX = false;
                } else {
                    spriteRenderer.flipX = true;
                }
            }
        }

        public void Death() {
            animator.SetBool(IsDead, true);
        }

        public void Jump() {
            animator.SetTrigger(IsJump);
        }

        public void Attack() {
            animator.SetTrigger("isAttack" + Random.Range(1, 4));
        }
    }
}