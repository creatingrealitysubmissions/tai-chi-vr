using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaiChiVoiceEvaluator : MonoBehaviour 
{
	private string[] instructorKeywords = new string[] { "instructor", "teacher", "mentor", "sensei", "roshi", "maestro" };
	private string[] pauseKeywords = new string[] { "stop", "halt", "pause" };
	private string[] playKeywords = new string[] { "play", "keep", "continue", "resume"};

	private Dictionary<string, int> numberTable = new Dictionary <string, int> 
	{ { "one", 1 }, { "two", 2 }, { "three", 3}, { "four", 4 }, {"for", 4}, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 } };

	public void Evaluate(string text)
	{	
		string[] words = text.Split(' ');
		//Check instructor keywords
		for (int i = 1; i < words.Length; i++)
		{
			foreach(string k in instructorKeywords)
			{ 
				if(words[i] == k || words[i] == k + 's')
				{
					if(numberTable.ContainsKey(words[i-1]))
					{
						Game.Instance.RepositionInstructors(numberTable[words[i-1]]);
					}
					int num = 0;
					Int32.TryParse(words[i-1], out num);
					if(num != 0)
						Game.Instance.RepositionInstructors(num);
				}
			}

			foreach(string k in pauseKeywords)
			{
				if(text.Contains(k))
				{
					foreach(TaiChiInstructor t in Game.Instance.Instructors)
					{
						t.Pause();
					}
				}
			}

			foreach(string k in playKeywords)
			{
				if(text.Contains(k))
				{
					foreach(TaiChiInstructor t in Game.Instance.Instructors)
					{
						t.Resume();
					}
				}
			}

		}
	}

}
