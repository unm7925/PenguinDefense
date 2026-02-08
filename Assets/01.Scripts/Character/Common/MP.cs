using System;
using UnityEngine;

public class MP:MonoBehaviour,IRecoverable
{
    [Header("MP")]
    
    private int mp;
    
    [SerializeField]private int maxMP;

    public void Init()
    {
        //maxMP = _maxMP;
        mp = 0;
    }
    
    public int CurrentMp()
    {
        return mp;
    }

    private void RecoverMp(int _mp)
    {
        mp = Mathf.Min(mp + _mp, maxMP);
    }


    public void Recover(int amount)
    {
        RecoverMp(amount);
    }
}