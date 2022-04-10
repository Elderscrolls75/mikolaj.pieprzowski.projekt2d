using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event System.Action OnZeroHealth;
    public event System.Action<int> OnHealthChanged;

    [SerializeField] int maxHealth;

    int currentHealth;
    public int Health {get {return currentHealth;} }

    private void Awake()
    {
        ResetHP();
    }

    public void ResetHP()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void DecreaseHP(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHP(int heal)
    {
        currentHealth += heal;
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Die()
    {
        OnZeroHealth?.Invoke();
    }
}
