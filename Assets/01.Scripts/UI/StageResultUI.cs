using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class StageResultUI:MonoBehaviour
{
        [SerializeField] private StageManager stageManager;
        
        private void Start()
        {
                stageManager.OnStageCleared += PrintResultUI;
                gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
                stageManager.OnStageCleared -= PrintResultUI;
        }

        private void PrintResultUI()
        {
                gameObject.SetActive(true);
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
