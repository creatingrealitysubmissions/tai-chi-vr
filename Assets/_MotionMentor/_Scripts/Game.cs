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

	void Start()
	{
		RepositionInstructors(Instructors.Count);
	}

	public void RepositionInstructors(int number)
	{
		if(number > 8 || number < 1)
			return;
		
		foreach(TaiChiInstructor t in Instructors)
		{
			t.gameObject.SetActive(false);
		}

		for (int i = 0; i < number; i++)
		{
			Instructors[i].gameObject.SetActive(true);
			Vector3 center = transform.position;
			Vector3 pos = CirclePoint(center, 3.5f, 360 / number * i);
			Quaternion rot = Quaternion.Euler(Vector3.forward);
			Instructors[i].transform.position = pos;
			Instructors[i].transform.rotation = rot;
		}
	}

	Vector3 CirclePoint (Vector3 center, float radius, float ang)
	{
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
         pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
         pos.y = center.y;
         return pos;
     }

}
