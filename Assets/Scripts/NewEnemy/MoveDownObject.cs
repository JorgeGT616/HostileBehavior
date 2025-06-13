using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownObject : MonoBehaviour {
    public float speed = 5;

    private void Update() {
        // transform.position += -transform.right * Time.deltaTime * speed;
        // transform into the world position not local position
        transform.position += Vector3.left * Time.deltaTime * speed;
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject,13);
    }
}
