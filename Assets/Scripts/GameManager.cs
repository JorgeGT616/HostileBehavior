using UnityEngine;
using UnityEngine.Audio; // Import the Audio namespace

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [SerializeField] private AudioMixer[] gameMixer; // Reference to the AudioMixer

    void Awake() {
        // Ensure only one instance of GameManager exists
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager across scenes
        } else {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Add other game management methods here
}
