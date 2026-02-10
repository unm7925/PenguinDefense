using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class LevelSystem:MonoBehaviour
{
        private EXPSystem expSystem;
        [SerializeField] private LevelUpUI levelUpUI;
        
        
        private void Awake()
        {
                expSystem = GetComponent<EXPSystem>();
        }
        
        private void OnEnable()
        {
                expSystem.OnLevelUp += levelUpUI.Play;
                
        }

        private void OnDisable()
        {
                expSystem.OnLevelUp -= levelUpUI.Play;
                
        }
}
