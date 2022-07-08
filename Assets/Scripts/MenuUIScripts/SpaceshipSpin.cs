using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceshipSpin : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public Animator shipAnimator;


    public void OnSelect(BaseEventData eventData)
	{
		shipAnimator.SetBool("isSelected", true);
	}

	public void OnDeselect(BaseEventData eventData)
	{
		shipAnimator.SetBool("isSelected", false);
	}
}
