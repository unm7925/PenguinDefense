using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController:MonoBehaviour
{
        [SerializeField] private float cooldown = 3f;
        [SerializeField] private TargetSystem targetSystem;
        [SerializeField] private Transform targetWall;
        
        public event Action<Enemy> OnEnemySpawn;
        public event Action OnSpawnComplete;
        
        private Vector2 spawnSize = new Vector2(2f,12f);
        public void Init()
        {
                
        }
        

        public void StartSpawn(WaveData _waveData)
        { 
                StartCoroutine(Spawn(_waveData));
        }
        

        private IEnumerator Spawn(WaveData _waveData)
        {
                
                foreach (var t in _waveData.enemies)
                {
                        for(int j=0; j<t.count;j++)
                        {
                                
                                Vector2 pos = RandomPos();
                                
                                Enemy enemy = Instantiate(t.prefab, pos,
                                                Quaternion.identity)
                                        .GetComponent<Enemy>();

                                enemy.Init(t.isBoss,targetWall,targetSystem);
                                
                                targetSystem.Register(enemy);
                                
                                OnEnemySpawn?.Invoke(enemy);
                                
                                yield return new WaitForSeconds(cooldown);
                        }
                }

                OnSpawnComplete?.Invoke();
        }

        private Vector2 RandomPos()
        {
                Vector2 pos = new Vector2(Random.Range(-spawnSize.x,spawnSize.x),spawnSize.y);
                return pos;
        }
        
}
