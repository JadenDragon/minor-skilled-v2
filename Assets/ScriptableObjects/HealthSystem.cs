using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    private int currentHealth;
    private int maxHealth;

    public HealthSystem (int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public float GetHealthPercent()
    {
        //cast my health to float values otherwise wrong return value
        return (float)currentHealth / maxHealth;
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        //set current health to 0 if it goes below 0
        if (currentHealth < 0)
            currentHealth = 0;
        
        //passes this value to all subscribers when health changes for damage
        if (OnHealthChanged != null)
            OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        //sets health to maxHealth if healing more than maxHealth
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        //passes this value to all subscribers when health changes for healing
        if (OnHealthChanged != null)
            OnHealthChanged(this, EventArgs.Empty);
    }
}
