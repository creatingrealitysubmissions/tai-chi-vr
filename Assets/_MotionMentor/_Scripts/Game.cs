using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour {

	public static Game Instance { get; set; }

	public GameObject Intro;

	public List<TaiChiInstructor> Instructors { get; set; }

	public int InstructorAmount {get; set;}
	public float AnimSpeed { get; set; }
	public bool UIEnabled {get; set;}

	void Awake()
	{
		AnimSpeed = 1;
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

		Init();
        //StartGame();
        UIEnabled = true;
    }

	void Init()
	{
		Instructors = GameObject.FindObjectsOfType<TaiChiInstructor>().ToList();
		InstructorAmount = Instructors.Count;
		foreach(TaiChiInstructor t in Instructors)
		{
			t.gameObject.SetActive(false);
		}
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

		InstructorAmount = number;
	}

	public void SpeedUpInstructors(float amount)
	{
		foreach(TaiChiInstructor t in Instructors)
		{
			AnimSpeed += amount;
			t.SetAnimSpeed(AnimSpeed);
		}
	}

	public void SetInstructorSpeed(float value)
	{
		foreach(TaiChiInstructor t in Instructors)
		{
			AnimSpeed = value;
			t.SetAnimSpeed(value);
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


	public void StartGame()
	{
		Intro.SetActive(false);
		FMODUnity.RuntimeManager.PlayOneShot ("event:/main/ui_sound_gamelan", transform.position);
		foreach(TaiChiInstructor t in Instructors)
		{
			t.gameObject.SetActive(true);
		}
		UIEnabled = true;
		RepositionInstructors(Instructors.Count);
	}
}
