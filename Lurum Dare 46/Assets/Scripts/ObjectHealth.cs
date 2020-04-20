using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDmg(int damage)
    {        
        Debug.Log("Taken Damage");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {       
        Destroy(gameObject);
        GetComponent<Collider2D>().enabled = false;
    }


}
