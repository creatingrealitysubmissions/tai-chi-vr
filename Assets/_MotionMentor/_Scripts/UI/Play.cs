using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : TaiChiIcon 
{
	[SerializeField] private MeshRenderer _pauseRend;
	private MeshRenderer _playRend;

	private bool _playing;

	public bool Playing
	{
		get
		{
			return _playing;
			_playRend.enabled = _playing;
			_pauseRend.enabled = !_playing;			
		}

		set
		{
			_playing = value;
			_playRend.enabled = value;
			_pauseRend.enabled = !value;	
		}
	}

	void Awake()
	{
		_playRend = GetComponent<MeshRenderer>();
		_playRend.enabled = true;
		_pauseRend.enabled = false;
		Playing = true;
	}

	public override void Select()
	{
		base.Select();
		Pause(Playing);
	}

	void Pause(bool pause)
	{
		if(pause)
			Game.Instance.SetInstructorSpeed(0);	
		if(!pause)
			Game.Instance.SetInstructorSpeed(1);
		Playing = !Playing;
	}
}
