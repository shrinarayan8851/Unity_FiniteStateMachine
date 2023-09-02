using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour, IPlayerState
{



    private float HSpeed = 10f;


    public void OnStateEnter(PlayerController player)
    {

    }

    public void OnStateExit(PlayerController player)
    {

    }

    public void UpdateState(PlayerController player)
    {
        player.moveXInput = Input.GetAxis("Horizontal");
        Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            player.anim.SetFloat("HSpeed", Mathf.Abs(player.moveXInput));
            player.anim.SetFloat("vSpeed", rb2d.velocity.y);

           
            if (player.grounded)
            {
                rb2d.velocity = new Vector2(player.moveXInput * HSpeed, rb2d.velocity.y);
                
            }
        }

       

    }

   

}
