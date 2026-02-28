using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private HP hp;
    public int maxHP = 1000;

    public event Action OnWallDestroyed;
    
    private void Awake()
    {
        hp = GetComponent<HP>();
    }

    private void Start()
    {
        hp.Init(maxHP);
    }
    

    private void OnEnable()
    {
        hp.OnDeath += HandleDeath;
    }
    private void OnDisable()
    {
        hp.OnDeath -= HandleDeath;
    }
    private void HandleDeath()
    {
        OnWallDestroyed?.Invoke();
        
        Destroy(gameObject);
    }
}
