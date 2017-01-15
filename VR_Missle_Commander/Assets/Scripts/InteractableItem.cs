using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour 
{
	protected Rigidbody rigidbody;

	protected bool currentlyInteracting;

	private float rotationFactor = 60f;
	private Quaternion rotationDelta;
	private float angle;
	private Vector3 axis;

	private WandController attachedWand;

	protected void Start () 
	{

		rigidbody = GetComponent<Rigidbody> ();
		
	}

	protected void Update () 
	{
		if (attachedWand && currentlyInteracting)
		{
			rotationDelta = attachedWand.transform.FindChild("Rotation Offset").transform.rotation * Quaternion.Inverse (transform.rotation);
			rotationDelta.ToAngleAxis (out angle, out axis);

			if (angle > 180)
			{
				angle -= 360;
			}

			this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
		}
		else
		{
			rotationDelta = Quaternion.Euler (0, 180, 0) * Quaternion.Inverse(transform.rotation);
			rotationDelta.ToAngleAxis (out angle, out axis);

			if (angle > 180)
			{
				angle -= 360;
			}

			this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
		}
	}

	public void BeginInteraction(WandController wand)
	{
		attachedWand = wand;

		currentlyInteracting = true;
	}

	public void EndInteraction(WandController wand)
	{
		if (wand == attachedWand) 
		{
			attachedWand = null;
			currentlyInteracting = false;
			this.rigidbody.angularVelocity = Vector3.zero;
		}
	}

	public bool IsInteracting()
	{
		return currentlyInteracting;
	}
}
