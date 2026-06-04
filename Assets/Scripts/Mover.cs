using UnityEngine;

// Mueve un objeto en una dirección a cierta velocidad.
public class Mover : MonoBehaviour
{
    public Vector3 direction;

    [SerializeField] public float speed;
    [SerializeField] int maximoSpeed;

    void Start()
    {
        // Solo usa la velocidad máxima como fallback si nadie asignó una velocidad
        // (antes era incondicional y machacaba la velocidad puesta por PlayerController,
        // dejándola en 0 según el orden de ejecución de los Start → la nave no se movía).
        if (speed <= 0f) speed = maximoSpeed;
    }

    void Update() => transform.Translate(direction * speed * Time.deltaTime);

    // El daño y la muerte los gestionan CombateJugador y PlayerController.Die().
    // Antes esto hacía Destroy(gameObject) cuando speed<=0, lo que BORRABA al jugador
    // entero al recibir un golpe (con la velocidad mal inicializada). Eliminado.
    public void TomarDaño(int daño) { }

    public void Curar(int curacion) { }
}
