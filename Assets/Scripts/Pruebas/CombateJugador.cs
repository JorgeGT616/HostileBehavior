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
        if (vida <= 0){
            vida = 0; // Ensure vida does not go below 0
            barraDeVida.CambiarVidaActual(vida);
            // Trigger death: hides the ship render and spawns the explosion effect
            playerController.Die();
            return;
        }
        barraDeVida.CambiarVidaActual(vida);

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
