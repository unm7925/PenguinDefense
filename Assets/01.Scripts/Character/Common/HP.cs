using System;
using UnityEngine;

public class HP:MonoBehaviour,IRecoverable
{
    [Header("HP")]
    
    private int hp;
    
    [SerializeField]private int maxHP;

    public event Action OnDeath;
    
    public void Init()
    {
        //maxHP = 
        hp = maxHP;
    }

    public int CurrentHp()
    {
        return hp;
    }

    private void Heal(int _hp)
    {
        hp = Mathf.Min(hp + _hp, maxHP);
    }


    public void Recover(int amount)
    {
        Heal(amount);
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
        
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
    
}
