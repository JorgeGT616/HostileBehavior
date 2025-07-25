using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour {
    public int vida;
    public int maximoVida;
    [SerializeField] BarraDeVida barraDeVida;

    PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        
    }

    private void Start() {
        vida = maximoVida;

        barraDeVida = (BarraDeVida)FindFirstObjectByType(typeof(BarraDeVida));
        if (barraDeVida == null) {
            Debug.LogError("BarraDeVida not found in the scene.");
            return;
        }

        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño (int daño) {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0){
            playerController.gameOver = true;
            vida = 0; // Ensure vida does not go below 0
        }
        
    }

    public void Curar (int curacion) {
        if ((vida + curacion) > maximoVida) {
            vida = maximoVida;
        } else {
            vida += curacion;
            barraDeVida.CambiarVidaActual(vida);
        }
        
    }

}
