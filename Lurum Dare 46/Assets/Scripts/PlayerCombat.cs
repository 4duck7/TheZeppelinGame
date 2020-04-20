using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int damage;
    public float AttackRange;
    public int maxAmmo = 160;
    public int currentAmmo;

    public float AttackRate = 1f;
    public float BombRate = 2f;
    float NextAttackTime = 0;

    public int maxBomb = 8;
    public int currentBomb;

    public LayerMask EnemyLayer;

    public Animator anim;
    public Transform attackPoint;
    //audio
    public AudioClip ShootingSound;
    public AudioClip EmptyClip;
    public AudioClip dialogue;
    public AudioSource audio;

    public GameObject bomb;
    public AmmoBar ab;
    public BombBar bb;

    void Start()
    {
        audio = GetComponent<AudioSource>(); 
        currentAmmo = maxAmmo;
        currentBomb = maxBomb;
        ab.SetMaxValue(maxAmmo);
        bb.SetMaxBomb(maxBomb);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= NextAttackTime)
            {
                if (currentAmmo > 0)
                {
                    Attack();
                    Debug.Log("Toggling Attack");
                    audio.PlayOneShot(ShootingSound, 0.7f);
                    currentAmmo -= 10;
                    ab.SetValue(currentAmmo);
                }
                else if (currentAmmo <= 0)
                {
                    Debug.Log("NoAmmo");
                    audio.PlayOneShot(EmptyClip, 0.7f);
                    ab.SetValue(currentAmmo);
                }
                NextAttackTime = Time.time + 1f / BombRate; //actually huge thanks to Brackeys for this part of code, which he learnt me
            }
            

        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time >= NextAttackTime)
            {
                if (currentBomb > 0)
                {

                    DropBombs();
                    Debug.Log("Toggling Bomb Drop");
                }
                else
                {
                    audio.PlayOneShot(dialogue, 0.7f);
                }
                NextAttackTime = Time.time + 1f / AttackRate;
            }                
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, EnemyLayer);
        anim.SetTrigger("Attack");        

        foreach (Collider2D Enemy in hitEnemy) //if enemy is in range of fire, then damage it
        {
            Enemy.GetComponent<Plane>().TakeDmg(damage);
        }
    }

    void DropBombs()
    {
        Vector2 bombPos = new Vector2(transform.position.x, transform.position.y -0.25f);
        Instantiate(bomb, bombPos, Quaternion.identity);
        currentBomb--;
        bb.SetBomb(currentBomb);
    }
}
