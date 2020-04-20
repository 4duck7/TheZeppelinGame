using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    public HealthBar hb;

    public int playerHealth;
    public int currentHealth;
    public int SceneToLoad;   

    private void Start()
    {
        currentHealth = playerHealth;
        hb.SetMaxHealth(playerHealth);
    }

    public void TakeDmg(int damage)
    {
        hb.SetHealth(currentHealth);
        Debug.Log("Taken Damage");
        currentHealth -= damage;       
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneToLoad);
        Destroy(gameObject);
        GetComponent<Collider2D>().enabled = false;
    }
   
}
