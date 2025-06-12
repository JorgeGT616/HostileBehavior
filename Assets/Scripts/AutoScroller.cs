
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movimiento del fondo
public class AutoScroller : MonoBehaviour
{
    //a medida que pasa el tiempo cambia el fondo del eje Y del material
    [SerializeField] CombateJugador player;

    [SerializeField] bool useDynamicScroll = false; // Toggle for dynamic scroll speed
    
    [SerializeField] float scrollSpeed = 0.5f;

    float minScrollSpeed = 0.01f; // Minimum scroll speed
    float maxScrollSpeed = 1.0f; // Maximum scroll speed

    float lastScrollSpeed = 0.5f; // Last scroll speed used
    float newScrollSpeed = 0.5f; // New scroll speed to be set
    
    [SerializeField] MeshRenderer mesh;
    

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        player = (CombateJugador) GameObject.FindFirstObjectByType(typeof(CombateJugador));
    }
    void FixedUpdate()
    {
        if (useDynamicScroll)
        {
            newScrollSpeed = Mathf.Clamp((float)player.vida / (player.maximoVida * 1.0f), minScrollSpeed, maxScrollSpeed);
        }
        else
        {
            newScrollSpeed = scrollSpeed;
        }

        // Interpolate between lastScrollSpeed and newScrollSpeed
        lastScrollSpeed = Mathf.Lerp(lastScrollSpeed, newScrollSpeed, Time.deltaTime * 5f);

        Vector2 offset = new Vector2(Time.time * lastScrollSpeed, 0);
        mesh.material.mainTextureOffset = offset;
    }
}
