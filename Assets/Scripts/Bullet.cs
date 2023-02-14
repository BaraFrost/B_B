using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    [SerializeField] bool enemyBullet;

    private void Start()
    {
       // Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) 
        {
            if (hitInfo.collider.CompareTag("Enemy")) 
            {
                
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Player") && enemyBullet)
            {

                hitInfo.collider.GetComponent<Player>().ChangeHealth(-damage);
            }
            DestroyProjectile();
        }

       // var direction = transform.lossyScale.x < 0 ? Vector2.left : Vector2.right;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
       // Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}