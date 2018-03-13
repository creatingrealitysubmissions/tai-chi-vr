using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour {

	public static Game Instance { get; set; }
	
	public List<TaiChiInstructor> Instructors { get; set; }

	void Awake()
	{
		//Check if instance already exists
		if (Instance == null)
			
			//if not, set instance to this
			Instance = this;
		
		//If instance already exists and it's not this:
		else if (Instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		Instructors = new List<TaiChiInstructor>();

		if(GameObject.FindObjectsOfType<TaiChiInstructor>() != null)
		{
			Instructors = GameObject.FindObjectsOfType<TaiChiInstructor>().ToList();
		}
	}

	public void RepositionInstructors(int number)
	{
		print("repositioning to " + number + " instructors.");
	}
}
