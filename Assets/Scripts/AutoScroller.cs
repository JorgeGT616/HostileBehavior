using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movimiento del fondo
public class AutoScroller : MonoBehaviour
{
    //a medida que pasa el tiempo cambia el fondo del eje Y del material

    public float scrollSpeed = 0.5f;
    [SerializeField] private MeshRenderer mesh;
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        mesh.material.mainTextureOffset = offset;
    }
}
