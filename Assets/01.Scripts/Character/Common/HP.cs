using System;
using UnityEngine;

public class HP:MonoBehaviour,IRecoverable
{
    [Header("HP")]
    
    private int currentHP;
    
    private int maxHP;

    public event Action OnDeath;
    
    public void Init(int _maxHP)
    {
        //maxHP = 
        maxHP = _maxHP;
        currentHP = maxHP;
    }

    public int CurrentHp()
    {
        return currentHP;
    }

    private void Heal(int _hp)
    {
        currentHP = Mathf.Min(currentHP + _hp, maxHP);
    }


    public void Recover(int amount)
    {
        Heal(amount);
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
        
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
    
}
