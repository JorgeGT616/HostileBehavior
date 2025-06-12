using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Import the new Input System

[System.Serializable]
public class Boundary {
    public float xMinimum, xMaximum, yMinimum, yMaximum;
}

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour {
    [SerializeField] Boundary boundary;
    
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] float ROTATION_SPEED = 40f; // Speed of rotation
    float nextFire;
    
    [SerializeField] GameObject shot;
    [SerializeField] GameObject ship;

    [SerializeField] Mover moverComponent;

    [SerializeField] Transform shotSpawn;
    
    PlayerInput playerInput;

    Vector2 movementInput;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>(); // Get PlayerInput component

        // Subscribe to input events
        playerInput.actions["Move"].performed += ctx => OnDirection(ctx.ReadValue<Vector2>());
        playerInput.actions["Move"].canceled += ctx => OnDirection(Vector2.zero);
        playerInput.actions["Fire"].performed += ctx => OnHasShoot();
    }

    private void Start() {
        moverComponent.speed = speed;

        ship = GameObject.FindGameObjectWithTag("Ship");
        if (ship == null) {
            Debug.LogError("Ship GameObject not found in the scene.");
        }
    }

    private void OnDirection(Vector2 direction) {
        movementInput = direction;

        if (direction.x != 0.0f || direction.y != 0) 
            ship.transform.rotation = Quaternion.Euler(180 + (movementInput.y * ROTATION_SPEED), (-movementInput.x * ROTATION_SPEED), -90);
        else 
            ship.transform.rotation = Quaternion.Euler(180, 0, -90);
        

        moverComponent.direction = new Vector3(movementInput.x, movementInput.y, 0f);
    }

    private void OnHasShoot() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void Update() {
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);

        transform.position = new Vector3(x, y);
    }
}