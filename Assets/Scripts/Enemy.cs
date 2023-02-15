using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Player player;
    public int health;
   // private float tomeBtwAttack;
    private float stopTime;
    private Animator anim;
    private float speed;
    [SerializeField]
    private float normalSpeed;
    [SerializeField]
    private float startStopTime;
    [SerializeField]
    private float timeBtwAttack;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float startTimeBtwAttack;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;

    }

    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            // Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        // camAnim.SetTrigger("shake");
        // Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                //anim.SetTrigger("EnemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
