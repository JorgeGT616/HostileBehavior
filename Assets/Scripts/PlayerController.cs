using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//movimientos del jugador con entrada del teclado

[System.Serializable]
public class Boundary { 
    public float xMinimum, xMaximum, yMinimum, yMaximum;
}

public class PlayerController : MonoBehaviour{
    public Mover moverComponent;
    public float speed;
    public Boundary boundary;

    void Update(){
        Vector3 desplazamiento = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, transform.position.z);
        moverComponent.DoMove(desplazamiento);

        //x: 9
        //y: 5
        //limitar el borde para el jugador y no se pueda alejar la nave 
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
        transform.position = new Vector3(x, y);

    }

}
