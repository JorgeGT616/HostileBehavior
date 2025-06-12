using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour {
    public int vida;
    public int maximoVida;
    [SerializeField] BarraDeVida barraDeVida;

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
            //Destroy(gameObject);
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
