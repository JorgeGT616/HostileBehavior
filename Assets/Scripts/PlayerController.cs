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
    [SerializeField] private List<Shooter> shooters;
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes

    private void Start() {
        moverComponent.speed = speed;
        InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;
    }

    private void OnDirection(Vector3 direction){
        moverComponent.direction = direction;
    }

    private void OnHasShoot() {
        foreach(var shooter in shooters) {
            shooter.DoShoot();
<<<<<<< Updated upstream
            
=======
>>>>>>> Stashed changes
        }
    }

    void Update(){
        //x: 9
        //y: 5
        //limitar el borde para el jugador y no se pueda alejar la nave 
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
        transform.position = new Vector3(x, y);
    }
}