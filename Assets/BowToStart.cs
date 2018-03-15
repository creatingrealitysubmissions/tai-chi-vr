using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowToStart : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("MainCamera"))
		{
			Game.Instance.StartGame();
		}
	}
}
