using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 30;
    private void Start()
    {
        Invoke("Die", 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerHealth>().TakeDmg(damage);
        Debug.Log("Player Entered");
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
