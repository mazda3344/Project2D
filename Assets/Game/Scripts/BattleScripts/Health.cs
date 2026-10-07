using Game.Scripts.PlayerControl;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.BattleScripts {
    [RequireComponent(typeof(AnimatorController))]
    public class Health : MonoBehaviour {
        [SerializeField] private float maxHealth = 100f;
        public float MaxHealth => maxHealth;
        private float currentHealth;
        public float CurrentHealth => currentHealth;
        public UnityAction<float> HealthChanged;
        public bool IsAlive => currentHealth > 0;

        private void Start() {
            // Debug.Log("Health::Start(); -- ");
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage) {
            // Debug.Log("TakeDamage(); -- damage:" + damage + ",go:" + gameObject, gameObject);
            currentHealth -= damage;
            HealthChanged.Invoke(currentHealth);
        }
    }
}