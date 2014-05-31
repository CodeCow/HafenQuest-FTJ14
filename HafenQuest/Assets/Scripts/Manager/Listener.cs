using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour {
	
	Human[] humans = Object.FindObjectsOfType<Human>();

	void Start () {

	    foreach(Human human in humans)
		{
			AddListener(human);
		}
	}

	private void AddListener(Human human)
	{
		Debug.Log ("Listener added");
	}






}
