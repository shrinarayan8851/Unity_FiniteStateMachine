using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour , IDamageable
{

    public float health = 100f;
    public Slider slider;
    public GameObject panal;
    public float fallThreshold = -10f;
    private bool isDone = false;
    public void TakeDamage(int damage)
    {
        health -= damage;
        slider.value -= 0.1f;
        if (health <= 0)
        {
            OnDie();
        }
    }
    void OnDie()
    {
        panal.SetActive(true);
        Time.timeScale = 0f;
        
    }

    private void Update()
    {
        if (transform.position.y <= fallThreshold)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if(!isDone)
        {
            panal.SetActive(true);
            isDone = true;
            Time.timeScale = 0f;

        }
    }

    IEnumerator WaitForLoad()
    {
       
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
        
    }

}
