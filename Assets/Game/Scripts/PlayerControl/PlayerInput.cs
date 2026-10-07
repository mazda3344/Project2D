using Game.Scripts.BattleScripts;
using UnityEngine;
namespace Game.Scripts.PlayerControl {
    [RequireComponent(typeof(PlayerMovement),
        typeof(Shooter))]
    public class PlayerInput : MonoBehaviour {
        private const string horizontalAxis = "Horizontal";
        private const string jumpButton = "Jump";
        private const string fire1Button = "Fire1";
        private PlayerMovement playerMovement;

        private void Awake() {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update() {
            float horizontalDirection = Input.GetAxis(horizontalAxis);
            bool isJumpButtonPressed = Input.GetButtonDown(jumpButton);
            bool isShoot = Input.GetButtonDown(fire1Button);
            playerMovement.MoveJumpAndShoot(horizontalDirection, isJumpButtonPressed, isShoot);
        }
    }
}