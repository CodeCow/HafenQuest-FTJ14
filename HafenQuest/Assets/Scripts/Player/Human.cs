using UnityEngine;
using System.Collections;

//DELEGATES



public class Human : MonoBehaviour {


	#region Variables
	private string name;
	private Vector3 destination;
	#endregion
	
	#region Methods
	void Awake()
	{
		MouseManager.Instance.onClick += MoveTo;
	}
	void Update () {
	
	}
	private void MoveTo(Vector3 pos)
	{
			this.transform.position = pos;
	}

	#endregion


}
