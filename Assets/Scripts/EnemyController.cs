
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [HideInInspector]
    public EnemyConfig config;
    [SerializeField] private MeshRenderer meshRenderer;

    private Mover mover;

    private void Start() {
        mover = GetComponent<Mover>();
        if (mover != null){
            mover.speed = config.moverSpeed;
        }

        if (config.material != null){
            meshRenderer.material = config.material;
        }
    }
    
}

