using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMountedDisplay : MonoBehaviour 
{
	private SteamVR_TrackedObject hmd;

	// Use this for initialization
	void Start () 
	{
		hmd = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
