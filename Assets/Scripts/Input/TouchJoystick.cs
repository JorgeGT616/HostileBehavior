using UnityEngine;
using UnityEngine.EventSystems;

// Joystick táctil 100% fiable: mueve el knob hijo y llama directamente a
// PlayerController.SetMovement, sin depender de los control schemes del Input System.
//
// Uso: ponlo en la imagen de FONDO del joystick (pivot 0.5, Raycast Target activado).
// Arrastra el knob hijo al campo "Knob". El fondo queda fijo y solo se mueve el knob.
[RequireComponent(typeof(RectTransform))]
public class TouchJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Tooltip("El mango (hijo) que se desplaza visualmente.")]
    [SerializeField] RectTransform knob;

    [Tooltip("Radio en píxeles que viaja el knob desde el centro.")]
    [SerializeField] float movementRange = 75f;

    [Tooltip("Opcional. Si se deja vacío, se busca el PlayerController en la escena.")]
    [SerializeField] PlayerController player;

    RectTransform baseRect;

    void Awake()
    {
        baseRect = GetComponent<RectTransform>();
        if (player == null) player = FindFirstObjectByType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);

    public void OnDrag(PointerEventData eventData)
    {
        if (player == null) player = FindFirstObjectByType<PlayerController>();

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            baseRect, eventData.position, eventData.pressEventCamera, out localPoint);

        Vector2 input = localPoint / Mathf.Max(1f, movementRange);
        if (input.magnitude > 1f) input = input.normalized;

        if (knob != null) knob.anchoredPosition = input * movementRange;
        if (player != null) player.SetMovement(input);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (knob != null) knob.anchoredPosition = Vector2.zero;
        if (player != null) player.StopMovement();
    }
}
