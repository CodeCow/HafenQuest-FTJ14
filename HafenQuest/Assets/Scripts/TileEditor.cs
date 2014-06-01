using UnityEngine;
using UnityEditor;
[RequireComponent(typeof(Camera))]

public class TileEditor : MonoBehaviour {
	public float scale;
	public Vector3 position;
	public Color lineColor;
	public void Statr()
	{
		// show up consistently
		EditorApplication.update += OnDrawGizmos;
	}
	public void OnDrawGizmos()
	{
		Gizmos.color = lineColor;
		Vector3 startPos = position;
		Vector3 []vertices = new Vector3[8];

		for(int i = 0; i < 8; i++)
		{
			vertices[i].x = i%2;
			vertices[i].y = (i/2)%2;
			vertices[i].z = (i/4)%2;
		}

		for(int z = 0; z < 3; z++)
		{
			position.z += scale;
			for(int y = 0; y < 2; y++)
			{
				position.y += scale;
				for(int x = 0; x < 3; x++)
				{
					position.x += scale;
					for(int i = 0; i < 8; i++)
					{
						for(int j = 0; j<8;j++)
						{
							if ((i^j) == 1 || (i^j) == 2 || (i^j) == 4)
								Gizmos.DrawLine(position + vertices[i] * scale,position + vertices[j] * scale);
						}
					}
				}
				position.x = startPos.x;
			}
			position.y = startPos.y;
		}

		position = startPos;

		
	}
}
