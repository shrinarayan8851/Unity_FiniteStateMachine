using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MonoBehaviour , IPlayerState
{

    public float jumpForce = 14f;
    private bool hasJumped = false;

    public void OnStateEnter(PlayerController player)
    {

    }

    public void OnStateExit(PlayerController player)
    {

    }

    public void UpdateState(PlayerController player)
    {

        if (!hasJumped && player.grounded)
        {
            player.anim.SetBool("ground", false);
            Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                hasJumped = true; 
            }
        }

        if(player.grounded && hasJumped)
        {
            player.TransitionToIdleState();
        }

      
    }
}

