using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
   private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for user input to switch animations
        if (Input.GetKeyDown(KeyCode.Space)) // Change this to your desired key
        {
            animator.SetBool("SideToSide", false);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("SideToSide", true);
        }
    }
}
