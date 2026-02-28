using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager:MonoBehaviour
{
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private EXPSystem expSystem;
    [SerializeField] private Wall wall;
    [SerializeField] private TargetSystem targetSystem;
    
    private List<WaveData> waveDatas; 
    
    public event Action<bool> OnStageCleared;
    public event Action<bool> OnGameOver;
    public event Action<int> OnStageChanged;
        
    private float waveDeley = 10f;
    
    private int waveIndex;

    private bool isStageCleared = false;

    private void LoadStage(int _stageIndex)
    {
        
        waveDatas = GameManager.Instance.AllStages[_stageIndex].waves;
        waveIndex = 0;
        
        spawnController.OnEnemySpawn += OnEnemySpawn;
        spawnController.OnSpawnComplete += HandleSpawnCompleted;
        
        StartWave(waveIndex);
    }

    private void Start()
    {
        LoadStage(GameManager.Instance.CurrentStageIndex);
        
        wall.OnWallDestroyed += GameOver;
        
        OnStageChanged?.Invoke(waveIndex+1);
    }

    private void StartWave(int _waveIndex)
    {
        if (_waveIndex + 1 == waveDatas.Count)
        {
            TriggerBossEncounter();
        }
        spawnController.StartSpawn(waveDatas[_waveIndex]);
    }
    
    private void OnEnemySpawn(Enemy _enemy)
    {
        _enemy.OnDead += OnEnemyDead;
    }
    
    private void OnEnemyDead(Enemy enemy,float _amount)
    {
        enemy.OnDead -= OnEnemyDead;
        
        expSystem.AddEXP(_amount);
        
        if (enemy.IsBoss)
        {
            ClearStage();
        }
    }
    

    private void HandleSpawnCompleted()
    {
        BeginStage();
    }
    
    private void BeginStage()
    {
        if (isStageCleared) return;
        
        waveIndex++;
        
        OnStageChanged?.Invoke(waveIndex+1);
        
        if (waveIndex >= waveDatas.Count) return;
        
        StartNextWaveWithDeley();
    }

    private void StartNextWaveWithDeley()
    {
        StartCoroutine(WaitAndStartNextWave());
    }

    private IEnumerator WaitAndStartNextWave()
    {
        yield return new WaitForSeconds(waveDeley);

        StartWave(waveIndex);
    }

    void TriggerBossEncounter()
    {
        
        // 대충 보스 몬스터 나왔다는 .ui나 이펙트 같은거 출현? 그런용도
    }

    void ClearStage()
    {
        if (isStageCleared) return;
        isStageCleared = true;
        
        Debug.Log("Clear");
        
        MemoryDel();
        OnStageCleared?.Invoke(true);
        
        // 스테이지 클리어 -> 이벤트 구독한 ui 다 튀어나오기 
    }

    void GameOver()
    {

        MemoryDel();
        OnGameOver?.Invoke(false);
    }

    void MemoryDel()
    {
        Time.timeScale = 0;
        targetSystem.AllClear();
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        spawnController.OnEnemySpawn -= OnEnemySpawn;
        spawnController.OnSpawnComplete -= HandleSpawnCompleted;
        wall.OnWallDestroyed -= GameOver;
    }
}
