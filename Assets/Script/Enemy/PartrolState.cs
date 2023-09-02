
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartrolState : MonoBehaviour , IEnemyState
{
    private float movespeed = 3f;

    
    public void UpdateState(Enemy enemy)
    {

        Vector3 direction = (enemy.currentTarget.position - enemy.transform.position).normalized;

        enemy.transform.Translate(direction * movespeed * Time.deltaTime);


        if (Vector3.Distance(enemy.transform.position, enemy.currentTarget.position) <= 0.21f)
        {
            enemy.currentTarget = enemy.playerPointA;
        }
        

        if(Vector3.Distance(enemy.transform.position , enemy.playerPointA.position) <= 0.23f)
        {
            enemy.currentTarget = enemy.playerPointB;
        }
       
    }

    
}
