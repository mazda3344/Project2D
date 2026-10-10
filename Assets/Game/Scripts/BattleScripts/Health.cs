using Game.Scripts.PlayerControl;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.BattleScripts 
{
    [RequireComponent(typeof(AnimatorController))] 
    public class Health : MonoBehaviour 
    {
        [Header("Health Settings")]
        [SerializeField] private float maxHealth = 100f;
        
        public float MaxHealth => maxHealth;
        public float CurrentHealth => currentHealth;
        public bool IsAlive => currentHealth > 0;

        private float currentHealth;
        public UnityAction<float> HealthChanged;
        public UnityAction OnDeath; 

        private AnimatorController animator;

        private void Awake()
        {
            animator = GetComponent<AnimatorController>();
        }

        private void Start() 
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage) 
        {
            if (!IsAlive) return;
            currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
            HealthChanged?.Invoke(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnDeath?.Invoke();
            if (TryGetComponent(out Collider2D col))
            {
                col.enabled = false;
            }
        }
    }
}
