using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickBehaviour : MonoBehaviour 
{
	[SerializeField] private float turnSpeed;
	private float currentRotation;
	[SerializeField] private string axis;
	[SerializeField] private float fireSpeed;
	[SerializeField] private float bulletStartVelocity;
	public GameObject bullet;
	[SerializeField] private Transform bulletStart;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (axis == "y") 
		{
			if (gameObject.GetComponent<InteractableItem> ().IsInteracting ()) 
			{
				currentRotation = -transform.rotation.eulerAngles.z;
				if (currentRotation < -180)
				{
					currentRotation = currentRotation + 360;
				}

				transform.root.transform.RotateAround (transform.root.transform.position, transform.root.transform.up, currentRotation * turnSpeed * Time.deltaTime);
				GameObject.FindObjectOfType<SteamVR_PlayArea> ().transform.RotateAround (transform.root.transform.position, transform.root.transform.up, currentRotation * turnSpeed * Time.deltaTime);
			}
		}
		else if (axis == "x")
		{
			if (gameObject.GetComponent<InteractableItem> ().IsInteracting ()) 
			{
				currentRotation = -transform.rotation.eulerAngles.x;
				if (currentRotation < -180)
				{
					currentRotation = currentRotation + 360;
				}

				GameObject.Find("Barrels").transform.RotateAround (GameObject.Find("Barrels").transform.position, GameObject.Find("Barrels").transform.transform.right, currentRotation * turnSpeed * Time.deltaTime);
			}
		}
	}

	public IEnumerator Fire ()
	{
		while (true) 
		{
			GameObject newBullet = Instantiate (bullet) as GameObject;
			newBullet.transform.position = bulletStart.position;
			newBullet.transform.rotation = bulletStart.rotation;
			newBullet.GetComponent<Rigidbody> ().AddRelativeForce(0, bulletStartVelocity, 0);
			yield return new WaitForSeconds (fireSpeed);
		}
	}
}
