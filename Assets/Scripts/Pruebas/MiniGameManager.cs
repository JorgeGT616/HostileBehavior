using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameManager : MonoBehaviour{
    [SerializeField] TMP_Text puntuacionText;
    public float puntuacionValue;

    [SerializeField] TMP_Text maxPuntuacionText;
    public float maxPuntuacion;

    [SerializeField] TMP_Text VelocidadText;
    public float Velocidad;

    AIEnemiga[] aiEnemiga;

    void Start() {
        maxPuntuacion= PlayerPrefs.GetFloat("MaxPuntuacion");
        maxPuntuacionText.text = "Max Points: " + maxPuntuacion.ToString("0");
        aiEnemiga = GameObject.FindGameObjectWithTag("Enemy").GetComponentsInChildren<AIEnemiga>();
    }

    void Update() {
        puntuacionValue += Time.deltaTime;
        puntuacionText.text = "Points: " + puntuacionValue.ToString("0");
        foreach (AIEnemiga ai in aiEnemiga) {
            Velocidad = ai.vel - 10;
        }
        VelocidadText.text = "Distance: " + Velocidad.ToString("0");

        if(maxPuntuacion < puntuacionValue){
            PlayerPrefs.SetFloat("MaxPuntuacion", puntuacionValue);

            maxPuntuacionText.text = "Max Points: " + puntuacionValue.ToString("0");
        }
    }

}
