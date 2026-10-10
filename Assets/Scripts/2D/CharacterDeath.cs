using Game.Scripts.BattleScripts;
using UnityEngine;

namespace Game.Scripts.PlayerControl 
{
    [RequireComponent(typeof(AnimatorController))] // Теперь этот атрибут логично держать здесь
    public class CharacterDeath : MonoBehaviour 
    {
        [SerializeField] protected Health health;
        private AnimatorController animatorController;

        protected void Start() 
        {
            if (!health) {
                health = GetComponent<Health>();
            }
            animatorController = GetComponent<AnimatorController>();
            
            if (health != null) {
                health.OnDeath += HandleDeath; // Подписываемся сразу на событие смерти
            }
        }

        private void OnDestroy() 
        {
            if (health != null) {
                health.OnDeath -= HandleDeath; // Защита от утечки памяти
            }
        }

        private void HandleDeath() 
        {
            if (animatorController != null) {
                animatorController.Death();
            }
            Invoke(nameof(DestroyMe), 2f);
        }

        private void DestroyMe() 
        {
            Destroy(gameObject);
        }
    }
}

