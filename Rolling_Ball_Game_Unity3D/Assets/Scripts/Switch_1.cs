using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;

public class Switch_1 : StateMachineBehaviour
{ 

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        string[] triggers = new string[] { "One", "Two", "Three" };
        System.Random random = new System.Random();
        int number = random.Next(triggers.Length);
        string pickTrigger = triggers[number];
        animator.SetTrigger(pickTrigger);
    }             
}
