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

    [SerializeField] GameObject shot;

    [SerializeField] GameObject ship;

    public Transform shotSpawn;
    public float fireRate;
    float nextFire;
    //[SerializeField] private List<Shooter> shooters;


    private void Start() {
        moverComponent.speed = speed;
        //InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;

        ship = GameObject.FindGameObjectWithTag("Ship");
        if (ship == null) {
            Debug.LogError("Ship GameObject not found in the scene.");
        }
    }

    private void OnDirection(Vector3 direction){
        moverComponent.direction = direction;
    }
    /*
    private void OnHasShoot() {
        foreach(var shooter in shooters) {
            shooter.DoShoot();
        }
    }
    */
    void Update(){
        //x: 9
        //y: 5
        //limitar el borde para el jugador y no se pueda alejar la nave 
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);

        if(x > 0 || y > 0){
            ship.transform.rotation = Quaternion.Euler(180 + (y*20), 0, -90);
            ship.transform.rotation = Quaternion.Euler(180, (x*20), -90);
        } else {
            ship.transform.rotation = Quaternion.Euler(180, 0, -90);
        }

        transform.position = new Vector3(x, y);

        if(Input.GetButton("Shoot") && Time.time > nextFire){

            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}