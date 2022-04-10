using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed;
    [SerializeField] float lifeLength;

    bool active;
    public void Shoot(Vector3 direction)
    {
        rb2d.AddForce(direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifeLength);
        active = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        HealthSystem healthSystem = other.gameObject.GetComponent<HealthSystem>();
        if(healthSystem != null)
        {
            if(active == true)
            {
                healthSystem.DecreaseHP(5);
            }
            active = false;
        }   
        Destroy(gameObject);
    }

    public void DestroyBullets()
    {
        Destroy(gameObject);
    }
}
