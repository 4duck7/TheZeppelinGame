using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour //Basic ai for the plane
{
    public int PlaneHealth;
    public int currentHealth;

    public float moveSpeed = 1;
    public int planeSight = 5;

    Transform target;
    Transform airport;
    
    public Animator anim;
    public GameObject bullet;
    public AudioSource ShootingSound;    

    float ReloadTime;
    public float startReloadTime;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        airport = GameObject.FindGameObjectWithTag("Airport").transform;
        currentHealth = PlaneHealth;

        ShootingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= planeSight)
        {
            if (Vector2.Distance(transform.position, target.position) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, target.position) <= 3)
            {
                ShootingSound.Play();
                anim.SetTrigger("Attack");
                if(ReloadTime <= 0)
                {
                    Attack();
                }  else
                {
                    ReloadTime -= Time.deltaTime;
                }         
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, airport.position, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {        
        Instantiate(bullet, transform.position, Quaternion.identity); //Deploy a bullet
        ReloadTime = startReloadTime; //start reloading
    }

    public void TakeDmg(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
