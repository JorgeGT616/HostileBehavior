using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Boundary
{
    public float xMinimum, xMaximum, yMinimum, yMaximum;
}

// Control del jugador con el Input System nativo de Unity 6.
//
// En lugar del componente PlayerInput (que hace device-pairing y filtra por control scheme,
// lo que rompe los On-Screen Controls en táctil), se habilita el Action Map directamente.
// Así TODOS los bindings (teclado, ratón, gamepad, touch y On-Screen Stick/Button) están
// activos a la vez, sin filtrado por esquema.
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] Boundary boundary;
    [SerializeField] float speed = 6f;
    [SerializeField] float rotationSpeed = 40f;

    [Header("Disparo")]
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotSpawn;
    [SerializeField] float fireRate = 0.25f;
    float nextFire;

    [Header("Nave / Skins")]
    [SerializeField] GameObject[] ships;
    [SerializeField] GameObject ship;

    [Header("Muerte")]
    [SerializeField] GameObject explosionPrefab;

    [Header("Input (Unity Input System)")]
    [Tooltip("Asset .inputactions del proyecto (HostileBehavior).")]
    [SerializeField] InputActionAsset inputAsset;
    [Tooltip("Action Map a usar dentro del asset.")]
    [SerializeField] string actionMapName = "Player";

    public bool gameOver = false;

    [SerializeField] Mover moverComponent;

    // --- Runtime ---
    InputActionMap playerMap;
    InputAction moveAction, fireAction, pauseAction;
    Vector2 movementInput;
    bool isFiring;

    void Awake()
    {
        if (inputAsset == null)
        {
            Debug.LogError("PlayerController: 'inputAsset' no asignado. Asigna el .inputactions en el Inspector.");
            return;
        }

        // Copia privada del asset para no interferir con el mapa de UI que usa el EventSystem.
        InputActionAsset asset = Instantiate(inputAsset);
        playerMap = asset.FindActionMap(actionMapName, throwIfNotFound: true);
        moveAction = playerMap.FindAction("Move", throwIfNotFound: true);
        fireAction = playerMap.FindAction("Fire", throwIfNotFound: true);
        pauseAction = playerMap.FindAction("Pause", throwIfNotFound: true);
    }

    void OnEnable()
    {
        if (playerMap == null) return;

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        fireAction.performed += OnFireStarted;
        fireAction.canceled += OnFireCanceled;
        pauseAction.performed += OnPause;

        playerMap.Enable();
    }

    void OnDisable()
    {
        if (playerMap == null) return;

        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        fireAction.performed -= OnFireStarted;
        fireAction.canceled -= OnFireCanceled;
        pauseAction.performed -= OnPause;

        playerMap.Disable();
    }

    void Start()
    {
        if (moverComponent != null) moverComponent.speed = speed;

        // Sustituye la nave por defecto por la skin seleccionada.
        GameObject existing = GameObject.FindGameObjectWithTag("Ship");
        if (existing != null) Destroy(existing);

        int skin = Mathf.Clamp(PlayerPrefs.GetInt("SelectedSkin", 0), 0, ships.Length - 1);
        ship = Instantiate(ships[skin], transform.position, Quaternion.Euler(180, 0, -90));
        ship.transform.SetParent(transform);
        ship.transform.localPosition = Vector3.zero;
        ships = null; // ya no se necesita el array tras instanciar
    }

    // ----- Callbacks de Input -----
    void OnMove(InputAction.CallbackContext ctx) => ApplyMovement(ctx.ReadValue<Vector2>());
    void OnFireStarted(InputAction.CallbackContext ctx) => isFiring = true;
    void OnFireCanceled(InputAction.CallbackContext ctx) => isFiring = false;
    void OnPause(InputAction.CallbackContext ctx) => TogglePause();

    void Update()
    {
        if (gameOver) return;

        if (isFiring && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
        float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    void ApplyMovement(Vector2 direction)
    {
        if (gameOver)
        {
            if (moverComponent != null) moverComponent.direction = Vector3.zero;
            return;
        }

        movementInput = direction;

        if (ship != null)
        {
            if (direction.sqrMagnitude > 0.0001f)
                ship.transform.rotation = Quaternion.Euler(180f + direction.y * rotationSpeed, -direction.x * rotationSpeed, -90f);
            else
                ship.transform.rotation = Quaternion.Euler(180f, 0f, -90f);
        }

        if (moverComponent != null)
            moverComponent.direction = new Vector3(direction.x, direction.y, 0f);
    }

    void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
    }

    /// <summary>
    /// Mata al jugador: oculta el render de la nave, lanza la explosión y detiene
    /// movimiento/disparo. Seguro de llamar más de una vez.
    /// </summary>
    public void Die()
    {
        if (gameOver) return;
        gameOver = true;

        isFiring = false;
        if (moverComponent != null) moverComponent.direction = Vector3.zero;

        if (explosionPrefab != null)
        {
            Vector3 pos = ship != null ? ship.transform.position : transform.position;
            Instantiate(explosionPrefab, pos, Quaternion.identity);
        }

        if (ship != null) ship.SetActive(false);

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
    }

    // ----- Hooks públicos opcionales para UI táctil propia (si NO usas On-Screen Controls) -----
    public void SetMovement(Vector2 direction) => ApplyMovement(direction);
    public void StopMovement() => ApplyMovement(Vector2.zero);
    public void FirePressed() => isFiring = true;
    public void FireReleased() => isFiring = false;
}
