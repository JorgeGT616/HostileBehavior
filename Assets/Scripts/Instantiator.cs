using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {
    public GameObject prefab;

    public void DoInstantiate(){
        if(prefab == null) {
            Debug.LogError("Prefab is not assigned in the Instantiator script in object: " + gameObject.name);
            return;
        }
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
