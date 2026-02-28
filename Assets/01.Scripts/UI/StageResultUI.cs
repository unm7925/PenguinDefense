using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageResultUI:MonoBehaviour
{
        [SerializeField] private StageManager stageManager;
        [SerializeField] private GameObject retryButton;
        private bool isWin;
        
        private void Start()
        {
                stageManager.OnStageCleared += PrintResultUI;
                stageManager.OnGameOver += PrintResultUI;
                gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
                stageManager.OnStageCleared -= PrintResultUI;
                stageManager.OnGameOver -= PrintResultUI;
        }

        private void PrintResultUI(bool _isWin)
        {
                if(isWin) 
                {
                        gameObject.SetActive(true);
                        retryButton.SetActive(true);
                }
                else 
                {
                        gameObject.SetActive(true);       
                        retryButton.SetActive(false);
                }
        }

        public void OnClickToRobby()
        {
                SceneManager.LoadScene(0);
        }
        
        public void OnClickNextStage()
        {
            
            GameManager.Instance.CurrentStageIndex++;
            SceneManager.LoadScene(1);
        }
}
