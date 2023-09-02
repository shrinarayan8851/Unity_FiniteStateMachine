using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public StateEvent onStartStateEvent;
    public StateEvent onExitStateEvent;

    private List<IPlayerState> activeStates = new List<IPlayerState>();


    [HideInInspector]
    public Animator anim;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool grounded = false;
    public float groundRadius = 0.15f;
   
    private bool facingRight = true;
    public static Vector3 theScale;
    public float moveXInput;

    private void Start()
    {

        AddState(new IdleState());
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {


        var statesCopy = new List<IPlayerState>(activeStates);


        foreach (var state in statesCopy)
        {
            state.UpdateState(this);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddState(new JumpState());
        }
        if (Input.GetKey(KeyCode.D))
        {

            AddState(new RunState());
        }
        else if (Input.GetKey(KeyCode.A))
        {
            AddState(new RunState());
        }
        else
        {
            moveXInput = 0f;
            anim.SetFloat("HSpeed", 0.000f);
        }
        



        // flip logic
        if (moveXInput > 0 && !facingRight)
            Flip();
        else if (moveXInput < 0 && facingRight)
            Flip();


        
    }

    public void AddState(IPlayerState newState)
    {
        activeStates.Add(newState);
        newState.OnStateEnter(this);
        onStartStateEvent.Invoke(newState);
    }

    public void RemoveState(IPlayerState stateToRemove)
    {
        if (activeStates.Contains(stateToRemove))
        {
            activeStates.Remove(stateToRemove);
            stateToRemove.OnStateExit(this);
            onExitStateEvent.Invoke(stateToRemove);
        }
    }

    public void TransitionToIdleState()
    {
        activeStates.Clear();
        AddState(new IdleState()); 
    }
    void Flip( )
    {
        facingRight = !facingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

  
}
