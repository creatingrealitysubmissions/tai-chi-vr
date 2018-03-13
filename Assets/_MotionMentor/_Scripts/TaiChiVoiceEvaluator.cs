using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiVoiceEvaluator : MonoBehaviour {

	public void Evaluate(string text)
	{
		int number = 1;
		Game.Instance.RepositionInstructors(number);
	}

}
