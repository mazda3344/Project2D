using Game.Scripts.Canvases;

namespace Game.Scripts.PlayerControl {
    public class PlayerCharacterDeath : CharacterDeath {
        private new void Start() {
            // Debug.Log("PlayerCharacterDeath::Start(); -- ");
            base.Start();
            base.health.HealthChanged += HealthChanged;
        }

        private void HealthChanged(float currentHealth) {
            if (!health.IsAlive) {
                MainCanvas.instance.ShowLosePanel();
            }
        }
    }
}