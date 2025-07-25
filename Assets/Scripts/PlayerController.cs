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
    [SerializeField] GameObject[] ships;
    [SerializeField] GameObject ship;

    public bool gameOver = false;

    [SerializeField] Mover moverComponent;

    [SerializeField] Transform shotSpawn;
    
    PlayerInput playerInput;

    Vector2 movementInput;

    void Awake() {
        playerInput = GetComponent<PlayerInput>(); // Get PlayerInput component

        // Subscribe to input events
        playerInput.actions["Move"].performed += ctx => OnDirection(ctx.ReadValue<Vector2>());
        playerInput.actions["Move"].canceled += ctx => OnDirection(Vector2.zero);
        playerInput.actions["Fire"].performed += ctx => OnHasShoot();

        playerInput.actions["Pause"].performed += ctx => OnPause();
    }

    void Start() {
        moverComponent.speed = speed;

        ship = GameObject.FindGameObjectWithTag("Ship");
        if (ship == null) {
            Debug.LogError("Ship GameObject not found in the scene.");
        } else Destroy(ship); // Destroy any existing ship instance
        ship = Instantiate(ships[PlayerPrefs.GetInt("SelectedSkin", 0)], transform.position, Quaternion.Euler(180, 0, -90)); // Default to first skin if not set
        ship.transform.SetParent(transform); // Set the ship as a child of the player controller
        ship.transform.localPosition = Vector3.zero; // Reset position to avoid offset
        // clear the ships array to avoid memory leaks
        ships = new GameObject[0]; // Clear the ships array to avoid memory leaks
    }

    void OnDirection(Vector2 direction) {

        if(gameOver) return; // Ignore input if game is over

        movementInput = direction;

        if (direction.x != 0.0f || direction.y != 0) 
            ship.transform.rotation = Quaternion.Euler(180 + (movementInput.y * ROTATION_SPEED), (-movementInput.x * ROTATION_SPEED), -90);
        else 
            ship.transform.rotation = Quaternion.Euler(180, 0, -90);
        

        moverComponent.direction = new Vector3(movementInput.x, movementInput.y, 0f);
    }

    void OnHasShoot() {
        if(gameOver) return; // Ignore input if game is over

        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate() {
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);

        transform.position = new Vector3(x, y);
    }

    void OnPause(){
        // Handle pause logic here
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // Toggle pause
        if (Time.timeScale == 0) {
            Debug.Log("Game Paused");
        } else {
            Debug.Log("Game Resumed");
        }
    }
}