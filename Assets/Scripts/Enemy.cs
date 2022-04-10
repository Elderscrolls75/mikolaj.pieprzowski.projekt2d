using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] HealthSystem healthSystem;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] float minInterval;
    [SerializeField] float maxInterval;
    float timer = 1f;

    float despawnPosition;

    public void Initialize(float leftScreenEdgePosition)
    {
        despawnPosition = leftScreenEdgePosition;
    }

    private void Awake() 
    {
        healthSystem.OnZeroHealth += HealthSystem_OnZeroHealth;  
    }

    private void Update() 
    {
        if(timer <= 0)
        {
            timer = Random.Range(minInterval, maxInterval);
            Shoot();
        }   

        timer -= Time.deltaTime; 

        if(transform.position.x < despawnPosition -3)
        {
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        Bullet createdBullet = Instantiate<Bullet>(bulletPrefab, transform.position, Quaternion.identity);
        createdBullet.Shoot(Vector3.left);
    }

    private void FixedUpdate() 
    {
        rb2d.velocity = Vector2.left * speed;    
    }

    private void HealthSystem_OnZeroHealth()
    {
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy() 
    {
        healthSystem.OnZeroHealth -= HealthSystem_OnZeroHealth;     
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        HealthSystem healthSystem = other.gameObject.GetComponent<HealthSystem>();
        {
            if(other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                healthSystem.DecreaseHP(10);    
            }
        }
    }
}
