using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemiga : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] float rangoAgro; //A cuanta distancia el enemigo ve al jugador 
    public float velocidadMov;
    public float velocidadPlayer;
    Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Distancia hasta el jugador 
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador: "+ distJugador);
        Mover velocidad = GetComponent<Mover>();
        velocidadPlayer = velocidad.speed;
        Debug.Log("Velocidad del jugador: "+ velocidad.speed);

        if(velocidadPlayer > 1){
            PerseguirJugador();
        }else {
            NoPerseguir();
        }
    }
    private void NoPerseguir(){
        rb2d.velocity = Vector2.zero;

    }
    private void PerseguirJugador(){
        if (transform.position.x < player.position.x){
            rb2d.velocity = new Vector2(velocidadMov,0f);
        }else if(transform.position.x > player.position.x){
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
        }
    }
    
       
   
}
