using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<StageData> AllStages;
    public int CurrentStageIndex;

    public static GameManager Instance;
    private void Awake() 
    {
        Time.timeScale = 1;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Application.targetFrameRate = 120;

    }

    private void Start()
    {
        CurrentStageIndex = 0;
    }
}