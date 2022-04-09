using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    [SerializeField] int vidas;
    [SerializeField] Slider sliderVidas;

    private void OnCollisionEnter2D(Collision2D otro) {
        if(otro.gameObject.CompareTag ("Enemigos")) {
            vidas--;
            sliderVidas.value = vidas;
        }
        
    }
    /*
    private void Start() {
        sliderVidas.maxValue = vidas;
        sliderVidas.value = sliderVidas.maxValue;
    }
    */
}
