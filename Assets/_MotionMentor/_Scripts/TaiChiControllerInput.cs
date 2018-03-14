using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TaiChiControllerInput : MonoBehaviour 
{	
	public bool UseSimulator;

	[Range(-1.0f, 1.0f)]
	public float touchpadX;
	
	[Range(-1.0f, 1.0f)]
	public float touchpadY;

	SteamVR_Controller.Device device;
	SteamVR_TrackedObject controller;

	public Vector2 Touchpad {get; set;}

	public Action OnTouchpadPressDown;

	void Awake () 
	{
		if(GetComponent<SteamVR_TrackedObject>() != null)
			controller = GetComponent<SteamVR_TrackedObject>();	
	}
	
	void Update () 
	{
		
		if(UseSimulator)
		{
			Touchpad = new Vector2(touchpadX, touchpadY);
			if(Input.GetKeyDown(KeyCode.Space))
				if(OnTouchpadPressDown!=null)
					OnTouchpadPressDown();
		}
		else
		{
			device = SteamVR_Controller.Input((int)controller.index);
			if(device.GetTouch(EVRButtonId.k_EButton_SteamVR_Touchpad))
				Touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
			
			if(device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
				if(OnTouchpadPressDown!=null)
					OnTouchpadPressDown();
		}

		//print(Touchpad.x.ToString() + " | " + Touchpad.y.ToString());
	}

	
}
