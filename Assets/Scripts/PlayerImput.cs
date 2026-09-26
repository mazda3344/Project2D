using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerImput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float horizontalDirection =Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtobPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

        playerMovement.Move();
    }
}
