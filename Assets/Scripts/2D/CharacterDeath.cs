using Game.Scripts.BattleScripts;
using UnityEngine;

namespace Game.Scripts.PlayerControl {
    public class CharacterDeath : MonoBehaviour {
        [SerializeField] protected Health2 health;
        private AnimatorController animatorController;
        public GameObject Player;

        protected void Start() {
            Debug.Log("CharacterDeath::Start(); -- ");
            if (health == null) {
                health = gameObject.GetComponent<Health2>();
                Debug.Log("CharacterDeath::Start(); -- health:" + health);
            }
            animatorController = GetComponent<AnimatorController>();
            Debug.Log("CharacterDeath::Start(); -- animatorController:" + animatorController);
            health.HealthChanged += HealthChanged;
        }

        private void HealthChanged(float currentHealth) {
            if (!health.IsAlive) {
                animatorController.Death();
                Invoke(nameof(DestroyMe), 2f);
            }
        }

        private void DestroyMe() {
            Player.SetActive(false);
        }
    }
}