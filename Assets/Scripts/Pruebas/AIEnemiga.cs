using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))] // Ensure the GameObject has a Rigidbody2D component
public class AIEnemiga : MonoBehaviour {
    [SerializeField] Transform player;
    //[SerializeField] GameObject jugador;

    public Boundary boundary;
    
    CombateJugador combateJugador;
    
    [SerializeField] float rangoAgro; //A cuanta distancia el enemigo ve al jugador 
    public float velocidadMov;
    public float speed = 2;
    public float vel;

    Vector3 initialPosition;
    
    Rigidbody2D rb2d;
    

    public GameObject Reinicia;

    [System.Serializable]
    public class Boundary { 
        public float xMinimum, xMaximum, yMinimum, yMaximum;
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        initialPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        combateJugador = GameObject.FindWithTag("Player").GetComponent<CombateJugador>();
    }

    void Start() {
        if (combateJugador == null) {
            Debug.LogError("CombateJugador component not found on the GameObject with tag 'Jugador'.");
        }

        Reinicia.gameObject.SetActive(false);

        player = GameObject.FindWithTag("Player").transform;
        if (player == null) {
            Debug.LogError("Player GameObject not found in the scene.");
        }
    }

    void Update() {
        // Distancia hasta el jugador 
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador: "+ distJugador);
        vel = distJugador;
        //Mover velocidad = GetComponent<Mover>();
        if(distJugador  <= 2){
            Reinicia.gameObject.SetActive(true);
        }else{
            Debug.Log("Velocidad del jugador: "+ combateJugador.vida);

            if(combateJugador.vida <= 3){
                PerseguirJugador();
            }else { 
                NoPerseguir();
            }
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
        float distancia = Vector2.Distance(transform.position, player.position);

        if (combateJugador.vida > 1) {
            // Se acerca pero no llega completamente (mantiene cierta distancia)
            float distanciaMinima = 7.5f * combateJugador.vida; // Puedes ajustar esta distancia mínima
            if (distancia > distanciaMinima) {
                Vector2 direccion = (player.position - transform.position).normalized;
                rb2d.linearVelocity = direccion * velocidadMov;
            } else {
                rb2d.linearVelocity = Vector2.zero;
            }
        } else {
            // Cuando le queda 1 vida, intenta llegar completamente al jugador
            Vector2 direccion = (player.position - transform.position).normalized;
            rb2d.linearVelocity = direccion * velocidadMov;
        }
    }
}
