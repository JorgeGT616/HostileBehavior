using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIEnemiga : MonoBehaviour {
    [SerializeField] Transform player;
    //[SerializeField] GameObject jugador;
    private CombateJugador combateJugador;
    [SerializeField] float rangoAgro; //A cuanta distancia el enemigo ve al jugador 
    public float velocidadMov;
    public float speed = 1;
    public float vel;
    Rigidbody2D rb2d;
    public Boundary boundary;

    public GameObject Reinicia;

[System.Serializable]
public class Boundary { 
    public float xMinimum, xMaximum, yMinimum, yMaximum;
}

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        combateJugador = FindObjectOfType<CombateJugador>();

        Reinicia.gameObject.SetActive(false);
    }

    void Update() {
        // Distancia hasta el jugador 
        if(player != null)
		{
            float distJugador = Vector2.Distance(transform.position, player.position);
            Debug.Log("Distancia del jugador: " + distJugador);
            vel = distJugador;
            //Mover velocidad = GetComponent<Mover>();

            Debug.Log("Velocidad del jugador: " + combateJugador.vida);

            if (combateJugador.vida <= 3)
            {
                PerseguirJugador();
            }
            else
            {
                NoPerseguir();
            }
        }

        else{
            rb2d.velocity = Vector2.zero;
            Reinicia.gameObject.SetActive(true);
            //SceneManager.LoadScene("Code");
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
