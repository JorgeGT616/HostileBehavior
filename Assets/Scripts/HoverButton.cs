using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class HoverButton : MonoBehaviour
{
    Button button;

    [SerializeField] AudioClip hoverSound;
    AudioSource audioSource;

    void Awake() {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseEnter() {
        if (button != null)
        {
            button.OnPointerEnter(null);
            audioSource.PlayOneShot(hoverSound); // Play hover sound
        }
    }

    void OnMouseExit() {
        if (button != null)
        {
            button.OnPointerExit(null);
        }
    }
}
