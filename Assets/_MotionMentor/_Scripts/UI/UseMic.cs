using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMic : TaiChiIcon 
{
	[SerializeField] TaiChiVoiceInput _taiChiVoiceInput;
	[SerializeField] Color _highlightColor;

	private Color _originalColor;

	void OnEnable()
	{
		TaiChiVoiceInput.OnStopRecording += RecordingStopped;
	}

	void OnDisable()
	{
		TaiChiVoiceInput.OnStopRecording -= RecordingStopped;
	}

	void RecordingStopped()
	{
		rend.material.color = _originalColor;
	}

	public override void Start()
	{
		_originalColor = rend.material.color;
	}

	public override void Select()
	{
		if(!_taiChiVoiceInput.IsRecording)
		{
			LTUtility.ButtonClickWobble(this.gameObject);
			rend.material.color = _highlightColor;
			_taiChiVoiceInput.StartRecording();
		}
	}

	
}
