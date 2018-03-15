using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : TaiChiIcon
{
	[SerializeField] Color _highlightColor;

	private Color _originalColor;
	bool _isHighlighted;

	//bleh
	public Play _play;

	public override void Start()
	{
		_originalColor = rend.material.color;
	}

	public override void Select()
	{
		base.Select();
		Game.Instance.SpeedUpInstructors(-.25f);
	}

	public override void Update()
	{
		if(Game.Instance.AnimSpeed < 1 && _play.Playing && !_isHighlighted)
		{
			rend.material.color = _highlightColor;
			_isHighlighted = true;
		}
		else if (Game.Instance.AnimSpeed >= 1 && _isHighlighted || !_play.Playing)
		{
			rend.material.color = _originalColor;
			_isHighlighted = false;
		}
	}
}
