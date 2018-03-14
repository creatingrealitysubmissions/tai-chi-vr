using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TaiChiInstructor : MonoBehaviour 
{
	private Animator anim;
	private Renderer meshRenderer;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}
	
	public void Disable()
	{
		meshRenderer.enabled = false;
	}

	public void Enable()
	{
		meshRenderer.enabled = true;
	}

	public void Pause()
	{
		print("paused");
		anim.speed = 0;
	}
	public void Resume()
	{
		print("resumed");
		anim.speed = 1;
	}

	public void SetAnimSpeed(float value)
	{
		anim.speed = value;
	}
}
