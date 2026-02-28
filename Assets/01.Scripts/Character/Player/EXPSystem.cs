using System;
using UnityEngine;

public class EXPSystem : MonoBehaviour
{
    private float baseEXP = 100f;
    private float currentEXP;
    private float requirEXP;
    private float EXPMul = 1.3f;
    private int level;
    
    public Action OnLevelUp;
    public Action<float,float> OnEXPChanged;
    
    public void Init()
    {
        level = 1;
        currentEXP = 0;
        requirEXP = baseEXP;
    }
    
    public void AddEXP(float amount)
    {
        currentEXP += amount;
        
        while(currentEXP >= requirEXP)
        {
            currentEXP -= requirEXP;
            level++;
            requirEXP = baseEXP  * Mathf.Pow(EXPMul,level);
            OnLevelUp?.Invoke();
        }
        OnEXPChanged?.Invoke(currentEXP,requirEXP);
    }
}
