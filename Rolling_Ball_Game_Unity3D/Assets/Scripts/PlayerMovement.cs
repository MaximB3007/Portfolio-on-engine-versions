using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement vars")]
        [SerializeField, Range(1, 10)] private float jumpForce;
        public bool isGrounded = false;
        [SerializeField, Range(1, 20)] private float speed;
        [SerializeField, Range(1, 10)] private float rotationSpeed;

        [Header("Settings")]
        [SerializeField] private Transform groundColliderTransform;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float jumpOffset;
        [SerializeField] private LayerMask groundMask;

        [Header("Audio")]
        [SerializeField] private AudioSource jumpSound, breakSound;

        private Rigidbody playerRigidbody;
        private Animator anim;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
        }
        
        public void MoveCharecter(float horizontal, float vertical, bool isJumpButtonPressed)
        {
            if (isGrounded)
            {
                float x = curve.Evaluate(horizontal * speed);
                float z = curve.Evaluate(vertical * speed);
                float y = playerRigidbody.velocity.y;

                Vector3 mowement = transform.TransformDirection(new Vector3(x, y, z));

                playerRigidbody.velocity = mowement;

                anim.SetTrigger("Landed");

                if (isJumpButtonPressed)
                {
                    Jump();
                }
            }

            if (playerRigidbody.velocity.x > 0.1 || playerRigidbody.velocity.y > 0.1)
                anim.SetTrigger("Walk");
            else
                anim.SetTrigger("Stop");
        }

        public void RotateCharecter(float rotation)
        {
            float x = transform.rotation.x;
            float z = transform.rotation.z;
            float y = rotation * rotationSpeed;
            transform.Rotate(x, y, z);
        }


        void Jump()
        {
            anim.SetTrigger("Jump");
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, jumpForce, playerRigidbody.velocity.z);
            jumpSound.Play();
        }

        public void DeathSound()
        {
            breakSound.Play();
        }
    }
}
