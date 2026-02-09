using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController:MonoBehaviour
{
        [SerializeField] private Enemy spawnPrefab;
        [SerializeField] private int spawnAmount;
        [SerializeField] private float cooldown = 3f;
        
        
        [SerializeField] private StageManager stageManager;

        private bool isSpawning = false;
        private int counting = 0;
        private Vector2 spawnSize = new Vector2(2f,12f);

        private void Awake()
        {
                
        }

        public void Init()
        {
                
        }

        private void Update()
        {
                if(counting < spawnAmount && !isSpawning)
                {
                        StartCoroutine(Spawn(spawnPrefab));
                }
        }

        private IEnumerator Spawn(Enemy prefab)
        {
                isSpawning = true;
                Vector2 pos = new Vector2(Random.Range(-spawnSize.x,spawnSize.x),spawnSize.y);
                Enemy enemy = Instantiate(spawnPrefab, pos, Quaternion.identity).GetComponent<Enemy>();

                enemy.OnDead += stageManager.ReturnEXP; 
                
                counting++;
                yield return new WaitForSeconds(cooldown);
                
                yield return isSpawning = false;
        }
        
        
}
