using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Import the EventSystems namespace for ISelectHandler and IDeselectHandler

[RequireComponent(typeof(AudioSource))]
public class SpaceshipSpin : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    Animator shipAnimator;

	// Get the Button component and play a sound on hover
	[SerializeField] AudioClip hoverSound;
	[SerializeField] AudioSource audioSource;

	Button button;
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		hoverSound = audioSource.clip; // Assign the hover sound from the AudioSource
		// from the child object get the Animator component
		shipAnimator = GetComponentInChildren<Animator>();
		button = GetComponent<Button>();
	}
	void Start()
	{

	}


    public void OnSelect(BaseEventData eventData)
	{
		shipAnimator.SetBool("isSelected", true);
		if (hoverSound != null)
		{
			audioSource.PlayOneShot(hoverSound);
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		shipAnimator.SetBool("isSelected", false);
	}
}
