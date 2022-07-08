using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public float destroyTime;

    public GameObject ExplosionFX;

    public void DoDestroy(){
        GameObject exp = Instantiate(ExplosionFX);
        exp.transform.position = gameObject.transform.position;
        Destroy(gameObject, destroyTime);
    }
}
