using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour {
    Instantiator ins;
    void Awake() => ins = GetComponent<Instantiator>();
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            other.GetComponent<CombateJugador>().Curar(1);
            other.GetComponent<Mover>().Curar(1);
            ins.DoInstantiate();
            Destroy(gameObject);
        }
    }
}
