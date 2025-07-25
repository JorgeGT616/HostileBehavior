using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] GameObject menuPrincipal;
    [SerializeField] GameObject menuConfiguracion;
    private bool start = false;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        start = true;
    }
    void LateUpdate()
    {
        if (!start)
        {
            return;
        }
        menuPrincipal.SetActive(true);
        menuConfiguracion.SetActive(false);
        start = false;
    }


    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir(){
        Debug.Log("Salir..");
        Application.Quit();
    }
}
