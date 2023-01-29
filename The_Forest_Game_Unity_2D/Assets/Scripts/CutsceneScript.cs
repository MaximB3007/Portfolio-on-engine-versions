using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


namespace Character.Inputs
{

    public class CutsceneScript : MonoBehaviour
    {
        [SerializeField] GameObject player, enemy, line;
        [SerializeField] CinemachineVirtualCamera vcam;
        [SerializeField] float introTime, disappearTime;
        [SerializeField] Button button;
        private bool change = true, end = false;

        void Start()
        {
            player.GetComponent<PlayerInput>().cutsceneIsOn = true;          
        }


        void Update()
        {
            if (introTime >= 0)
            {
                introTime -= Time.deltaTime;
            }
            else
            {
                if (change)
                {   
                    vcam.Priority = 1;
                    change = false;
                    line.SetActive(true);
                }
            }

            if (end)
            {   
                if(disappearTime > 0)
                {
                    disappearTime -= Time.deltaTime;
                }
                else
                {
                    enemy.SetActive(false);
                    end = false;
                }
            }
        }

        public void End()
        {
            player.GetComponent<PlayerInput>().cutsceneIsOn = false;
            line.SetActive(false);
            vcam.Priority = 10;
            end = true;
        }
    }
}
