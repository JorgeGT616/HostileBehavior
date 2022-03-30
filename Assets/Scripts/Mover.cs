using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de mover los objetos que se requiera, sin importar que objeto sea 
public class Mover : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
