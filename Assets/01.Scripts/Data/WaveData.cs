using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo
{
    public bool isBoss;
    public Enemy prefab;
    public int count;
    public float spawnInterval;
    public float enemyHpMultiplier;
    public float enemySpeedMultiplier;
}



[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    public List<EnemySpawnInfo> enemies;
}
