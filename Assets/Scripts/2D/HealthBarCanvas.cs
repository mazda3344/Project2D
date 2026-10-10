using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.BattleScripts {
    public class HealthBarCanvas : MonoBehaviour {
        [SerializeField] private Image healthImage;
        [SerializeField] private Health health;

        private void Start() {
            if (!health) {
                health = transform.parent.GetComponent<Health>();
            }
            health.HealthChanged += HealthChanged;
        }

        private void HealthChanged(float currentHealth) {
            SetHealthFillAmount(currentHealth / health.MaxHealth);
        }

        private void SetHealthFillAmount(float fillAmount) {
            healthImage.fillAmount = fillAmount;
        }
    }
}