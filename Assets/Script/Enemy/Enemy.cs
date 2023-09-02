using UnityEngine;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    private List<IEnemyState> activeStates = new List<IEnemyState>();
    public Transform playerPointA;
    public Transform playerPointB;
    [HideInInspector]
    public Transform currentTarget;


    private bool damageTakenThisFrame = false;

    private void Start()
    {
        currentTarget = playerPointB;
        AddState(new PartrolState());

    }

    private void FixedUpdate()
    {


        var statesCopy = new List<IEnemyState>(activeStates);


        foreach (var state in statesCopy)
        {
            state.UpdateState(this);
        }
    }

    public void AddState(IEnemyState newState)
    {
        activeStates.Add(newState);
    }

    public void RemoveState(IEnemyState stateToRemove)
    {
        if (activeStates.Contains(stateToRemove))
        {
            activeStates.Remove(stateToRemove);
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!damageTakenThisFrame)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
                damageTakenThisFrame = true;
            }
        }
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        damageTakenThisFrame = false;
    }
}