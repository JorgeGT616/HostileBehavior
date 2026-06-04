using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // For UI pointer events

// OnMouseEnter / OnMouseExit are physics messages that only fire for GameObjects with a
// Collider. They NEVER fire on UI (Canvas) elements, so the hover sound never played.
// IPointerEnterHandler / IPointerExitHandler are the correct events for UI and also fire
// on touch devices (web / mobile) when a finger goes down on the button.
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Button button;

    [SerializeField] AudioClip hoverSound;
    AudioSource audioSource;

    void Awake() {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (button != null && button.interactable)
        {
            if (hoverSound != null) audioSource.PlayOneShot(hoverSound); // Play hover sound
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        // Nothing extra to do on exit; kept for symmetry / future use.
    }
}
