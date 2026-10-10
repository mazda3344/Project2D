using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Game.Scripts.BattleScripts;
namespace Game.Scripts.PlayerControl 
{
    [RequireComponent(typeof(AnimatorController))]
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float currentHealth;
        public UnityAction<float> HealthChanged;
        private bool isAlive;
        private AnimatorController animatorController;

        public bool IsAlive { get; internal set; }

        private void Awake()
        {
            currentHealth = maxHealth;
            isAlive = true;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            CheckIsAlive();
            HealthChanged.Invoke(currentHealth);
        }

        private void CheckIsAlive()
        {
            if(currentHealth > 0)
                isAlive = true;
            else
                isAlive = false;
                animatorController.Death();
        }
        
    }
}
