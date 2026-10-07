using Game.Scripts.BattleScripts;
using Game.Scripts.PlayerControl;
using UnityEngine;

namespace Game.Scripts.PlayerControl {
    public class CharacterDeath : MonoBehaviour {
        [SerializeField] protected Health health;
        private AnimatorController animatorController;

        protected void Start() {
            // Debug.Log("CharacterDeath::Start(); -- ");
            if (!health) 
            {
                health = transform.GetComponent<Health>();
            }
            animatorController = GetComponent<AnimatorController>();
            health.HealthChanged += HealthChanged;
        }

        private void HealthChanged(float currentHealth) {
            if (!health.IsAlive) 
            {
                animatorController.Death();
                Invoke(nameof(DestroyMe), 2f);
            }
        }

        private void DestroyMe() 
        {
            Destroy(gameObject);
        }
    }
}