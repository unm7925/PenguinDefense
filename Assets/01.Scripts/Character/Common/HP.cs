using System;
using UnityEngine;

public class HP:MonoBehaviour,IRecoverable
{
    [Header("HP")]
    
    private int currentHP;
    
    private int maxHP;

    public event Action OnDeath;
    public event Action<int,int> OnHPChanged;
    
    public void Init(int _maxHP,float _hpMultiplier =1f)
    {
        //maxHP = 
        maxHP = (int)(_maxHP * _hpMultiplier);
        currentHP = maxHP;
    }

    public int CurrentHp()
    {
        return currentHP;
    }

    private void Heal(int _hp)
    {
        currentHP = Mathf.Min(currentHP + _hp, maxHP);
        OnHPChanged?.Invoke(currentHP,maxHP);
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
        
        OnHPChanged?.Invoke(currentHP,maxHP);
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
    
}
