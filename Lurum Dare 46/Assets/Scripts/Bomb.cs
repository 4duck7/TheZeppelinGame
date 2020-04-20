using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Animator anim;
    public AudioSource explosion;    
    
    void Start()
    {
        Invoke("Die", 2f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetTrigger("Exploded");
        Debug.Log("Exploded");
        explosion.Play();
    }

    public void Die()
    {        
        Destroy(gameObject);
    }
}
