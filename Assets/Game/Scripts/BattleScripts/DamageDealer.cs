using UnityEngine;
namespace Game.Scripts.BattleScripts {
    public class DamageDealer : MonoBehaviour {
        [SerializeField] private bool bullet = true;
        [SerializeField] private float damage = 50f;

        private void OnTriggerEnter2D(Collider2D collider) {
            // Debug.Log("DamageDealer(); -- collider:" + collider + ",tag:" + collider.tag, collider.gameObject);
            // Debug.Log("DamageDealer(); -- gameObject:" + gameObject + ",tag:" + gameObject.tag, gameObject);
            // if (collider.CompareTag("Damageable")) {
            if (!collider.CompareTag(gameObject.tag)) {
                if (collider.TryGetComponent(out Health otherHealth)) {
                    otherHealth.TakeDamage(damage);
                    if (bullet) {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}