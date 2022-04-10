using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemiga : MonoBehaviour {
    [SerializeField] Transform player;
    //[SerializeField] GameObject jugador;
    [SerializeField] private Mover mover;
    [SerializeField] float rangoAgro; //A cuanta distancia el enemigo ve al jugador 
    public float velocidadMov;
    public float velocidadPlayer; //ejemplo
    Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        mover = FindObjectOfType<Mover>();
    }

    void Update() {
        // Distancia hasta el jugador 
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador: "+ distJugador);
        //Mover velocidad = GetComponent<Mover>();
        
        Debug.Log("Velocidad del jugador: "+ mover.speed);

        if(mover.speed <= 1){
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
