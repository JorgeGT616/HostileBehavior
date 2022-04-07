using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterDo : MonoBehaviour { 
    [SerializeField] private UnityEvent action;
    [SerializeField] private float tiempoEntreDaño;

    private float tiempoSiguienteDaño;

    private GameObject collisionee;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            tiempoSiguienteDaño -= Time.deltaTime;
            if(tiempoSiguienteDaño <= 0) {
                collision.GetComponent<CombateJugador>().TomarDaño(5);
                tiempoSiguienteDaño = tiempoEntreDaño;
                
            }
        
        }
        collisionee = collision.gameObject;
        action.Invoke();
    }

    public void DestroyCollsionee() {
        if (collisionee != null){
            Destroy(collisionee);
        }
    }
}
