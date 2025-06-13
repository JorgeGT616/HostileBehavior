using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    public void ReiniciarNuestroJuegos(){
        SceneManager.LoadScene("Code2");
    }

    public void RegresarAMenu()
	{
        SceneManager.LoadScene("TitleScreen");
	}
    
}
