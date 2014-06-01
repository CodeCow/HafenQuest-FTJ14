using UnityEngine;
using System.Collections;

//DELEGATES



public class Human : MonoBehaviour {


	#region Variables
	private string name;
	private Vector3 destination;
	private Vector3 targetPosition;
	#endregion
	
	#region Methods
	void Awake()
	{
		MouseManager.Instance.onClick += MoveTo;
		targetPosition = this.transform.position;
	}
	void Update () {
		//Quaternion newRot = Quaternion.LookRotation(targetPosition);
		//this.transform.rotation = Quaternion.Slerp(transform.rotation,newRot, 1.5f * Time.deltaTime);
		this.transform.position = Vector3.Lerp(transform.position,targetPosition,3 * Time.deltaTime);
	}
	private void MoveTo(Vector3 pos)
	{
		targetPosition = pos;
		targetPosition.y = this.transform.collider.bounds.size.y + pos.y;
		//this.transform.position = pos;
	}

	#endregion


}
