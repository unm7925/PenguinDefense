using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private HP hp;
    public int maxHP = 1000;

    private void Awake()
    {
        hp = GetComponent<HP>();
    }

    private void Start()
    {
        hp.Init(maxHP);
    }
}
