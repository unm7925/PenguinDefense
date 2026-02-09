using System;
using TMPro;
using UnityEngine;

public class LevelSystem:MonoBehaviour
{
        private EXPSystem expSystem;
        [SerializeField] private TextMeshProUGUI levelText;
        
        private void Awake()
        {
                expSystem = GetComponent<EXPSystem>();
        }
        

        private void printSelectUI()
        {
                levelText.gameObject.SetActive(true);
                
        }

        private void LevelUpEffect()
        {
                
        }
        
        private void OnEnable()
        {
                expSystem.OnLevelUp += printSelectUI;
                expSystem.OnLevelUp += LevelUpEffect;
        }

        private void OnDisable()
        {
                expSystem.OnLevelUp -= printSelectUI;
                expSystem.OnLevelUp -= LevelUpEffect;
        }
}
