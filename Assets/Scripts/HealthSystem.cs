using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event System.Action OnZeroHealth;
    public event System.Action OnHealthChanged;

    [SerializeField] int maxHealth;

    int currentHealth;
    public int Health {get {return currentHealth;} }

    private void Awake() 
    {
        currentHealth = maxHealth;
    }

    public void DecreaseHP(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHP(int heal)
    {
        currentHealth += heal;
        OnHealthChanged?.Invoke();
    }

    void Die()
    {
        OnZeroHealth?.Invoke();
    }
}
