using UnityEngine;
using UnityEngine.Audio; // Import the Audio namespace
using UnityEngine.UI; // Import the UI namespace for Slider

public class MixerCustomSettings : MonoBehaviour
{
    [SerializeField] AudioMixer gameMixer; // Reference to the AudioMixer
    [SerializeField] Slider volumeSlider; // Reference to the UI Slider for volume control
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string mixerName = gameMixer.name + "Volume";
        float volume = PlayerPrefs.GetFloat(mixerName, 0f); // Get the saved volume or default to 0

        gameMixer.SetFloat("Volume", volume);
        volumeSlider = GetComponent<Slider>(); // Get the Slider component attached to this GameObject
        // let's get the name of the AudioMixer from the PlayerPrefs
        SetVolume(volume); // Set the volume in the AudioMixer
        Debug.Log("MixerCustomSettings: AudioMixer loaded with name: " + mixerName);
        volumeSlider.value = volume; // Set the slider value to the saved volume
    }

    public void SetVolume(float volume)
    {
        // Set the volume parameter in the AudioMixer
        gameMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat(gameMixer.name + "Volume", volume); // Save the volume to PlayerPrefs
    }
}
