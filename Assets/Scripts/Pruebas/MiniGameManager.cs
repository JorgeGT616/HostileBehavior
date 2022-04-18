using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour{
    public Text puntuacionText;
    public float puntuacionValue;

    public Text maxPuntuacionText;
    public float maxPuntuacion;

    private void Start() {
        maxPuntuacion= PlayerPrefs.GetFloat("MaxPuntuacion");
        maxPuntuacionText.text = maxPuntuacion.ToString("0.00");
    }

    private void Update() {
        puntuacionValue += Time.deltaTime;
        puntuacionText.text = puntuacionValue.ToString("0.00");

        if(maxPuntuacion < puntuacionValue){
            PlayerPrefs.SetFloat("MaxPuntuacion", puntuacionValue);

            maxPuntuacionText.text = puntuacionValue.ToString("0.00");
        }
    }

}
