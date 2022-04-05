
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [HideInInspector]
    public EnemyConfig config;
    [SerializeField] private MeshRenderer meshRenderer;

    private Mover mover;
    private Shooter[] shooters;

    private void Start() {
        mover = GetComponent<Mover>();
        if (mover != null){
            mover.speed = config.moverSpeed;
        }

        if (config.material != null){
            meshRenderer.material = config.material;
        }

        if (config.isShooter) {
            shooters = GetComponentsInChildren<Shooter>();
            if (shooters != null && shooters.Length > 0) {
                StartCoroutine(ShootForever());
            }
        }
    }

    public void OnDie() {
        Debug.Log("Hey! Im dead!");
        GameController.Instance.OnDie(gameObject, config.score);
    }

    private IEnumerator ShootForever() {
        yield return new WaitForSeconds(config.shootInitialWaitTime);
        while (true){
            foreach(var shooter in shooters) {
                shooter.DoShoot();
            }
            yield return new WaitForSeconds(config.shootCadence);
        }
    }
}

