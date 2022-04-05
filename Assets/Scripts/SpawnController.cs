using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    public List<GameObject> enemyPrefab;
    public List<EnemyConfig> enemyConfigs;

    public Vector3 spawnReferencePosition;
    public Quaternion spawnRotation;
    public int amountToSpawn;
    public float spawCadence;
    public float initialWaitTime;

    private void Start() {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    private IEnumerator EnemySpawnerCoroutine() {
        yield return new WaitForSeconds(initialWaitTime);
        for(int i = 0; i < amountToSpawn; i++){
            Vector3 randomPosition = new Vector3(spawnReferencePosition.x, Random.Range(-spawnReferencePosition.y, spawnReferencePosition.y), spawnReferencePosition.z);
            SpawnEnemy(randomPosition, spawnRotation);
            yield return new WaitForSeconds(spawCadence);
        }
    }
    public void SpawnEnemy(Vector3 enemyPosition, Quaternion rotation){
        int randomIndex = Random.Range(0, enemyPrefab.Count);
        var enemyInstance = Instantiate(enemyPrefab[randomIndex], enemyPosition, rotation);
        var enemyController = enemyInstance.GetComponent<EnemyController>();
        if (enemyController != null){
            int randomConfigIndex = Random.Range(0, enemyConfigs.Count);
            enemyController.config = enemyConfigs[randomConfigIndex];
        }
    }
}
