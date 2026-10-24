using Game.Scripts.BattleScripts;
using UnityEngine;

namespace Game.Scripts.PlayerControl 
{
    public class CharacterDeath1 : MonoBehaviour 
    {
        [SerializeField] protected Health2 health;
        private AnimatorController animatorController;
        public GameObject Player;
        private PlayerInput Movement;
        private Shooter Shoot;
        

        protected void Start() 
        {
            Debug.Log("CharacterDeath::Start(); -- ");
            if (health == null) 
            {
                health = gameObject.GetComponent<Health2>();
                Debug.Log("CharacterDeath::Start(); -- health:" + health);
            }
            animatorController = GetComponent<AnimatorController>();
            Debug.Log("CharacterDeath::Start(); -- animatorController:" + animatorController);
            health.HealthChanged += HealthChanged;
            Movement = gameObject.GetComponent<PlayerInput>();
            Shoot = gameObject.GetComponent<Shooter>();
        }

        private void HealthChanged(float currentHealth) 
        {
            if (!health.IsAlive) 
            {
                animatorController.Death();
                Destroy(Player, 0.5f);
            }
        }
    }
}