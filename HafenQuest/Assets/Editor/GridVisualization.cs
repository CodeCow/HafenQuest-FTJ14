using UnityEngine;
using UnityEditor;
using System.Collections;


[CanEditMultipleObjects]
[CustomEditor(typeof(TileEditor))]
public class GridVisualization: Editor{

	private SerializedProperty scale;
	private SerializedProperty pos;
	private SerializedProperty color;
	private SerializedObject script;
	public void OnEnable()
	{
		EditorApplication.update += SceneView.RepaintAll;
		//set up stuff
		script =  new SerializedObject(target);
		scale = script.FindProperty("scale");
		pos = script.FindProperty("position");
		color = script.FindProperty("lineColor");

	}
	public override void OnInspectorGUI()
	{
		script.Update();
		//serializedObject.Update();
		EditorGUILayout.PropertyField(scale, new GUIContent("Tile Size"));
		EditorGUILayout.PropertyField(pos, new GUIContent("Position"));
		EditorGUILayout.PropertyField(color, new GUIContent("Color"));

		script.ApplyModifiedProperties();

	}

	public void OnSceneGUI()
	{
		Vector3 []vertices = new Vector3[8];
		if(GUI.changed)
		{
			EditorUtility.SetDirty(target);
			
		}

		Handles.color = color.colorValue;
		//TileEditor tileEditor = (TileEditor)script.targetObject;

		/*for(int z = 0; z < pos.vector3Value.z; z++)
		{
			for(int y = 0; y < pos.vector3Value.y; y++)
			{
				for(int x = 0; x < pos.vector3Value.x; x++)
				{

				}
			}
		}
		*/
	   
		for(int i = 0; i < 8; i++)
		{
			vertices[i].x = i%2;
			vertices[i].y = (i/2)%2;
			vertices[i].z = (i/4)%2;
		}
		/*for(int  y = 0; y < 10; y++)
		{
			Vector3 loc = pos.vector3Value;
			loc.y += 1;
			pos.vector3Value = loc;
			script.ApplyModifiedProperties();
			for(int i = 0; i < 8; i++)
			{
				for(int j = 0; j<8;j++)
				{
					if ((i^j) == 1 || (i^j) == 2 || (i^j) == 4)
						Handles.DrawLine(pos.vector3Value + vertices[i] * scale.floatValue, pos.vector3Value + vertices[j] * scale.floatValue);
				}
			}

		}
		*/

	}


}
