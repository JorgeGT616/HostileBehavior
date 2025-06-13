using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour{
    public Text puntuacionText;
    public float puntuacionValue;

    public Text maxPuntuacionText;
    public float maxPuntuacion;

    public Text VelocidadText;
    public float Velocidad;

    AIEnemiga[] aiEnemiga;

    void Start() {
        maxPuntuacion= PlayerPrefs.GetFloat("MaxPuntuacion");
        maxPuntuacionText.text = maxPuntuacion.ToString("0.00");
        aiEnemiga = FindObjectsByType<AIEnemiga>(FindObjectsSortMode.None);
    }

    void Update() {
        puntuacionValue += Time.deltaTime;
        puntuacionText.text = puntuacionValue.ToString("0.00");
        foreach (AIEnemiga ai in aiEnemiga) {
            if(ai.vel > Velocidad)
                Velocidad = ai.vel;
        }
        VelocidadText.text = Velocidad.ToString("0.00");

        if(maxPuntuacion < puntuacionValue){
            PlayerPrefs.SetFloat("MaxPuntuacion", puntuacionValue);

            maxPuntuacionText.text = puntuacionValue.ToString("0.00");
        }
    }

}
