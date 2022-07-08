using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour{

    public TMP_Text puntuacionText;
    public float puntuacionValue;

    public TMP_Text maxPuntuacionText;
    public float maxPuntuacion;

    public TMP_Text VelocidadText;
    public float Velocidad;
    public Slider distanceSlider;

    private AIEnemiga aiEnemiga;

    private void Start() {
        maxPuntuacion= PlayerPrefs.GetFloat("MaxPuntuacion");
        maxPuntuacionText.text = "MAX SCORE: " + maxPuntuacion.ToString("0");
        aiEnemiga = FindObjectOfType<AIEnemiga>();
    }

    private void Update() {
        puntuacionValue += Time.deltaTime;
        puntuacionText.text = "SCORE: " + puntuacionValue.ToString("0");

        Velocidad = aiEnemiga.vel;
        // Slider inverso, 20 - velocidad
        distanceSlider.value = (28 - Velocidad);

        if(maxPuntuacion < puntuacionValue){
            PlayerPrefs.SetFloat("MaxPuntuacion", puntuacionValue);

            maxPuntuacionText.text = "MAX SCORE: " + puntuacionValue.ToString("0");
        }
    }

}
