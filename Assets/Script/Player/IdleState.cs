using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  MonoBehaviour , IPlayerState
{
    public void OnStateEnter(PlayerController player)
    {

    }

    public void OnStateExit(PlayerController player)
    {

    }

    public void UpdateState(PlayerController player)
    {
        player.grounded = Physics2D.OverlapCircle(player.groundCheck.position, player.groundRadius, player.whatIsGround);
        player.anim.SetBool("ground", player.grounded);
        player.anim.SetBool("Idle", true);

        if(player.grounded)
        {
            player.TransitionToIdleState();
        }
    }
}
