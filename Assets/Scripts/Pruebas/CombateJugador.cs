using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour {
    [SerializeField] public int vida;
    [SerializeField] int maximoVida;
    [SerializeField] private BarraDeVida BarraDeVida;

    private void Start() {
        vida = maximoVida;
        BarraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño (int daño) {
        vida -= daño;
        BarraDeVida.CambiarVidaActual(vida);
        if (vida <= 0){
            //Destroy(gameObject);
        }
        
    }

    public void Curar (int curacion) {
        if ((vida + curacion) > maximoVida) {
            vida = maximoVida;
        } else {
            vida += curacion;
            BarraDeVida.CambiarVidaActual(vida);
        }
        
    }

}
