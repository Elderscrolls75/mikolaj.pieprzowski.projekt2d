using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed;
    [SerializeField] float lifeLength;

    public void Shoot(Vector3 direction)
    {
        rb2d.AddForce(direction * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifeLength);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);    
    }
}
