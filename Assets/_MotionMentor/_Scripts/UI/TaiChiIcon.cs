using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiIcon : MonoBehaviour 
{

	protected MeshRenderer rend;

	public virtual void Awake()
	{
		rend = GetComponent<MeshRenderer>();
	}

	public virtual void Start()
	{

	}

	public virtual void Select()
	{
		FMODUnity.RuntimeManager.PlayOneShot ("event:/main/ui_sound_gamelan", transform.position);
		LTUtility.ButtonClickWobble(this.gameObject);
	}	

	public virtual void Update()
	{

	}
}
