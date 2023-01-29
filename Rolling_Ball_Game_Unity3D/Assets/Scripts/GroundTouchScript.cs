//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

namespace PlayerBall.Inputs
{
    public class GroundTouchScript : MonoBehaviour
    {
        public GameObject mainBody;
        private PlayerMovement playerMovement;

        void Start()
        {
            playerMovement = mainBody.GetComponent<PlayerMovement>();
        }

        void OnTriggerStay(Collider other)
        {
            
            if (other.gameObject.CompareTag("Ground"))
            {
                playerMovement.isGrounded = true;               
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                playerMovement.isGrounded = false;
            }
        }
    }
}
