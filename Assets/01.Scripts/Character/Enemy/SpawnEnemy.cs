using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy:MonoBehaviour
{
        [SerializeField] private GameObject spawnPrefab;
        [SerializeField] private int spawnAmount;
        [SerializeField] private float cooldown = 3f;

        private bool isSpawning = false;
        private int counting = 0;
        private Vector2 spawnSize = new Vector2(2f,12f);

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

        private IEnumerator Spawn(GameObject prefab)
        {
                isSpawning = true;
                Vector2 pos = new Vector2(Random.Range(-spawnSize.x,spawnSize.x),spawnSize.y);
                Instantiate(spawnPrefab, pos, Quaternion.identity);
                counting++;
                yield return new WaitForSeconds(cooldown);
                
                yield return isSpawning = false;
        }
        
        
}
