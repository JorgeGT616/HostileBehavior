using UnityEngine;
using UnityEngine.EventSystems;

// Botón de disparo táctil 100% fiable: llama directamente a PlayerController,
// sin depender del Input System ni de los control schemes (que en Android suelen
// dejar de leer el "gamepad virtual" de los On-Screen Controls).
//
// Uso: ponlo en la Image/Button del disparo. Esa imagen debe tener "Raycast Target" activado.
public class TouchFireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("Opcional. Si se deja vacío, se busca el PlayerController en la escena.")]
    [SerializeField] PlayerController player;

    void Awake()
    {
        if (player == null) player = FindFirstObjectByType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player == null) player = FindFirstObjectByType<PlayerController>();
        if (player != null) player.FirePressed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (player != null) player.FireReleased();
    }
}
