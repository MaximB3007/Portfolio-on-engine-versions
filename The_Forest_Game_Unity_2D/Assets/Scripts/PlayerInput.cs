using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private Health health;
        public bool cutsceneIsOn;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (!cutsceneIsOn)
            {
                if (health.isAlive)
                {
                    float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
                    bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

                    if (Input.GetKeyDown(KeyCode.W))
                        playerMovement.Attack();

                    playerMovement.Move(horizontalDirection, isJumpButtonPressed);
                }
            }
        }
    }
}
