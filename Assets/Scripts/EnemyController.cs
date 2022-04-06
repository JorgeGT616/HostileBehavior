
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [HideInInspector]
    public EnemyConfig config;
    [SerializeField] private MeshRenderer meshRenderer; //entrar dentro de meshRenderer
    [SerializeField] private MeshFilter meshFilter; //entrar dentro de meshFilter

    private Mover mover;
    private Shooter[] shooters;

    private void Start() {
        mover = GetComponent<Mover>();
        if (mover != null){
            mover.speed = config.moverSpeed;
        }
        //cambio del color de material
        if (config.material != null){
            meshRenderer.material = config.material;
        }
<<<<<<< Updated upstream

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
=======
        //cambio del modelo
        if (config.mesh != null){
            meshFilter.mesh = config.mesh;
        }
        if(config.isShooter) {
            shooters = GetComponentsInChildren<Shooter>();
            if(shooters != null && shooters.Length > 0) {
                    StartCoroutine(ShootForever());
            }
            
        }
    }
    private IEnumerator ShootForever(){
        yield return new WaitForSeconds(config.shootInitialWaitTime);
        while(true) {
            foreach(var shooter in shooters) {
                shooter.DoShoot();
            }
            yield return new WaitForSeconds(config.shootCadence);
        }
    
    }   
>>>>>>> Stashed changes
}

