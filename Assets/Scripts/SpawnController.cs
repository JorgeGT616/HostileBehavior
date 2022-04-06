using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField] private List<EnemyWavesConfig> wavesConfigs;
    [SerializeField] private Quaternion spawnRotation;
    [SerializeField] private float initialWaitTime;
    [SerializeField] private float cadenceBetweenWaves;

    private void Start() {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    private IEnumerator EnemySpawnerCoroutine() {
        yield return new WaitForSeconds(initialWaitTime);
        foreach(var wave in wavesConfigs) {
            foreach(var enemy in wave.enemies) {
                Vector3 enemyPosition = Vector3.zero;
                if(enemy.useSpecificYPosition){
                    enemyPosition = enemy.spawnReferencePosition;
                } else {
                    enemyPosition = new Vector3(enemy.spawnReferencePosition.x, Random.Range(-enemy.spawnReferencePosition.y, enemy.spawnReferencePosition.y), enemy.spawnReferencePosition.z);
                }
                SpawnEnemy(enemy.enemyPrefab, enemy.config, enemyPosition, spawnRotation);
                yield return new WaitForSeconds(wave.cadence);
            }
            yield return new WaitForSeconds(cadenceBetweenWaves);
        }
        
    }
    public void SpawnEnemy(EnemyController enemyPrefab, EnemyConfig config, Vector3 enemyPosition, Quaternion rotation){
<<<<<<< Updated upstream
        var enenmyInstance = Instantiate(enemyPrefab, enemyPosition, rotation);
        enenmyInstance.config = config;
=======
        var enemyInstance = Instantiate(enemyPrefab, enemyPosition, rotation);
        enemyInstance.config = config;
>>>>>>> Stashed changes
    }
}
