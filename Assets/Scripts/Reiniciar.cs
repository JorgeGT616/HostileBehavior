using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    public void ReiniciarNuestroJuegos(){
        SceneManager.LoadScene("Game");
    }

    public void RegresarAMenu()
	{
        SceneManager.LoadScene("TitleScreen");
	}
    
}
