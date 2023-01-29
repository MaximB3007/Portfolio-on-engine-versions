using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PlayerBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private PlayerMovement playerMovement;
        public GameObject particles;
        public GameObject ball;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            //anim.SetFloat("Velocity", playerRigidbody.velocity.magnitude);

            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);
            float rotation = Input.GetAxis(GlobalStringVars.ROTATION);

            horizontal *= Time.deltaTime * 100;
            vertical *= Time.deltaTime * 100;
            rotation *= Time.deltaTime * 50;

            playerMovement.MoveCharecter(horizontal, vertical, isJumpButtonPressed);
            playerMovement.RotateCharecter(rotation);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("DeathTrigger"))
            {
                ball.SetActive(false);
                particles.SetActive(true);               
                StartCoroutine(timer_1());
                playerMovement.DeathSound();
            }

            if (other.CompareTag("Finish"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        IEnumerator timer_1()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
