using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        if(healthBar == null)
        {
            healthBar = GameObject.FindGameObjectWithTag("PlayerHpBar").GetComponent<HealthBar>();
        }
    }

    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth < 1)
        {
            Die();
        }
    }
    public void Heal(int healAmount = 1)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += healAmount;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void Die()
    {
        //Stop taking player input
        //Play death animation
        Destroy(gameObject);
        //Go to Game Over screen
    }
}
