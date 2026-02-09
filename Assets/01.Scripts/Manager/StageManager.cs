using System;
using UnityEngine;

public class StageManager:MonoBehaviour
{
    [SerializeField] private EXPSystem expSystem;

    private void Awake()
    {
        
    }

    public void ReturnEXP(float amount)
    {
        expSystem.AddEXP(amount);
    }
}
