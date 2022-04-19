using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemiga : MonoBehaviour {
    [SerializeField] Transform player;
    //[SerializeField] GameObject jugador;
    [SerializeField] private CombateJugador combateJugador;
    [SerializeField] float rangoAgro; //A cuanta distancia el enemigo ve al jugador 
    public float velocidadMov;
    public float speed = 1;
    Rigidbody2D rb2d;
    public Boundary boundary;

[System.Serializable]
public class Boundary { 
    public float xMinimum, xMaximum, yMinimum, yMaximum;
}

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        combateJugador = FindObjectOfType<CombateJugador>();
    }

    void Update() {
        // Distancia hasta el jugador 
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador: "+ distJugador);
        //Mover velocidad = GetComponent<Mover>();
        
        Debug.Log("Velocidad del jugador: "+ combateJugador.vida);

        if(combateJugador.vida <= 3){
            PerseguirJugador();
        }else {
            NoPerseguir();
        }
    }
    private void NoPerseguir(){
        //rb2d.velocity = Vector2.zero;
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
        transform.position = new Vector3(x, y);
        transform.position += -transform.right * Time.deltaTime * speed;

    }
    private void PerseguirJugador(){
        if (transform.position.x < player.position.x){
            rb2d.velocity = new Vector2(velocidadMov,0f);
        }
        
        /*else if(transform.position.x > player.position.x){
            rb2d.velocity = new Vector2(-velocidadMov, 0f);
        }*/
    }
    
       
   
}
