using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownObject : MonoBehaviour {
    public float speed = 5;

    private void Start() {
        Destroy(gameObject,13);
    }

    private void Update() {
        transform.position += -transform.right * Time.deltaTime * speed;
    }
}
