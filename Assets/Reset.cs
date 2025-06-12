using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReiniciarNuestroJuegos()
    {
        SceneManager.LoadScene("Code");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
