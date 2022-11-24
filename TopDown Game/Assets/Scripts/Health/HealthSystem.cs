using System;
public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    private int health;
    private int healthMax;
    
    //constructor
    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    //returns health
    public int GetHealth()
    {
        return health;
    }

    //returns health percent
    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    //damages health
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }

    //heals health
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }
}
