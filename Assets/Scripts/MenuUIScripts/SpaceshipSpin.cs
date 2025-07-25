using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceshipSpin : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public Animator shipAnimator;

	void Awake()
	{
		// from the child object get the Animator component
		shipAnimator = GetComponentInChildren<Animator>();
	}

    public void OnSelect(BaseEventData eventData)
	{
		shipAnimator.SetBool("isSelected", true);
	}

	public void OnDeselect(BaseEventData eventData)
	{
		shipAnimator.SetBool("isSelected", false);
	}
}
