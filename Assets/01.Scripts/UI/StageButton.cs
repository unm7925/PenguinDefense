
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class StageButton:MonoBehaviour
    {
        [SerializeField] private int stageIndex;

        public void OnSelectStage()
        {
            GameManager.Instance.CurrentStageIndex = stageIndex;
            SceneManager.LoadScene(1);
        }
    }
