using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiVoiceEvaluator : MonoBehaviour 
{
	public string[] instructorKeywords = new string[] { "instructor", "teacher", "mentor", "sensei", "roshi" };


	
	public void Evaluate(string text)
	{	
		string[] words = text.Split(' ');

		for (int i = 0; i < words.Length; i++)
		{
			foreach(string k in instructorKeywords)
			{ 
				if(words[i] == k)
				{
					//if(words)
				}
			}
		}

		Game.Instance.RepositionInstructors(3);
	}

}
