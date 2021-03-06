﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_wind_sound : MonoBehaviour {

	// FMOD setup

	public float SpeedFactor = 0.4f;


    private Vector3 previous;

	// Rigidbody
	Rigidbody rb;
	FMODUnity.StudioEventEmitter wind_event;
	FMOD.Studio.ParameterInstance handspeed;


	// Use this for initialization
	void Start () {
		// Start wind event
		rb = GetComponent<Rigidbody>();
		wind_event = GetComponent<FMODUnity.StudioEventEmitter>();

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 current = transform.position;
		Vector3 v3Velocity = (current - previous);
        previous = current;
		float scaled_velocity = SpeedFactor * v3Velocity.magnitude / Time.deltaTime;
		scaled_velocity = Mathf.Clamp (scaled_velocity, 0.0f, 1.0f);
		//handspeed.setValue (scaled_velocity);
		wind_event.SetParameter ("handspeed", scaled_velocity);
	}
}
