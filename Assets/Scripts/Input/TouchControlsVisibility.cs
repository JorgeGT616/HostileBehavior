using UnityEngine;
using UnityEngine.InputSystem;

// Muestra los controles On-Screen (joystick + botón de disparo) SOLO cuando el juego
// corre en un dispositivo táctil (móvil o web en móvil).
// Dentro del Unity Editor y en escritorio quedan ocultos, así solo ves el juego.
//
// Cómo usarlo:
//   - Pon este componente en un objeto que SIEMPRE esté activo (p.ej. el Canvas).
//   - Arrastra a "touchControls" los objetos raíz del joystick y del botón de disparo.
public class TouchControlsVisibility : MonoBehaviour
{
    [Tooltip("Raíces del joystick y del botón de disparo que solo deben verse en táctil.")]
    [SerializeField] GameObject[] touchControls;

    [Tooltip("Mostrarlos también dentro del Unity Editor (útil para probarlos con el ratón).")]
    [SerializeField] bool showInEditor = false;

    void Awake()
    {
        bool show = ShouldShow();
        foreach (var control in touchControls)
        {
            if (control != null) control.SetActive(show);
        }
    }

    bool ShouldShow()
    {
        // En el editor: oculto por defecto (solo se ve el juego), salvo que actives el flag.
        if (Application.isEditor) return showInEditor;

        // En una build: solo si hay pantalla táctil (cubre móvil nativo y web en móvil).
        return Touchscreen.current != null || Application.isMobilePlatform;
    }
}
