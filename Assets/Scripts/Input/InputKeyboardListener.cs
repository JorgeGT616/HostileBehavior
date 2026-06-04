using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: Input is handled by PlayerController through the new Input System (PlayerInput).
// This component used to read input with the legacy UnityEngine.Input API
// (Input.GetAxis / Input.GetButtonDown). The project's Active Input Handling is set to
// "Input System Package (New)" only, so those legacy calls threw an exception EVERY frame.
// Nothing subscribes to InputProvider, so the old Update was also dead code.
// It is kept as an (inert) component so existing scene references stay valid.
public class InputKeyboardListener : MonoBehaviour, IInputeable {
    public void GetDirection(Vector3 direction){
        InputProvider.TriggerDirection(direction);
    }

    public void ShootPressed() {
        InputProvider.TriggerOnHasShoot();
    }
}
