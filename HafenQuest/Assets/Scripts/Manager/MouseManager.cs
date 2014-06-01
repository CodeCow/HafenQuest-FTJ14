using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	#region Variables
	// SET THESE IN THE INSPECTOR
	public float mouseRange = 250; // how far into 3d space you can click
	private string tag = "Walkable";
	private static MouseManager instance;
	private Vector3 targetPos;
	#endregion

	#region Event Handler
	public delegate void OnClickEvent(Vector3 g);
	public event OnClickEvent onClick;
	#endregion

	#region Methods

	private MouseManager()
	{

	}
	public static MouseManager Instance
	{
		get{

			if(instance == null)
				instance = GameObject.FindObjectOfType(typeof(MouseManager)) as MouseManager;
			return instance;
		}

	}
	void Update () {
	
		if(Input.GetMouseButtonDown(0))
		{
			GetWalkableEntity();
		}
	}
	private void GetWalkableEntity()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		if(Physics.Raycast(ray,out hit,mouseRange))
		{
			if(hit.transform.CompareTag(this.tag))
			{
				targetPos = hit.point;
				onClick(targetPos);
				Debug.Log ("WorldPos: " + hit.point);
			}
		}
	}
	#endregion
}
