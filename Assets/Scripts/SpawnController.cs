using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    public GameObject enemyPrefab;

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
        Instantiate(enemyPrefab, enemyPosition, rotation);
    }
}
