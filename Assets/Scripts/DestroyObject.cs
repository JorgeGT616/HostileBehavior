using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public float destroyTime = 0.0f;

    [SerializeField]
    bool destroyOnStart = false;
    
    public void DoDestroy(){
        Destroy(gameObject, destroyTime);
    }

    void Update() {
        if (destroyOnStart) {
            DoDestroy();
            destroyOnStart = false; // Ensure it only runs once
        }
    }
}
