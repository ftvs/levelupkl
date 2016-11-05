using UnityEngine;
using System.Collections;

/// <summary>
///  Save child objects as json
/// </summary>
public class SaveShapeToJson : MonoBehaviour {
	void OnEnable()
	{
		Shape shape = this.ObjectsToShape();

		if (Debug.isDebugBuild) {
			Debug.Log("path" + Application.persistentDataPath);
		}

		string shapestring = JsonUtility.ToJson(shape);

		var fileWriter = System.IO.File.CreateText(Application.persistentDataPath + "/shapesolution.json");
		fileWriter.Write(shapestring);
		fileWriter.Close();

		this.enabled = false;
	}

	/// <summary>
	/// Reads child object locations and returns them as json.
	/// </summary>
	/// <returns>The shape model object.</returns>
	public Shape ObjectsToShape()
	{
		Shape shape = new Shape();

		int maxWidth = 0;
		int maxDepth = 0;
		int maxHeight = 0;

		foreach (Transform childTransform in this.transform)
		{
			Vector3 position = childTransform.localPosition;
			maxWidth = Mathf.Max(maxWidth, (int)position.x);
			maxDepth = Mathf.Max(maxDepth, (int)position.z);
			maxHeight = Mathf.Max(maxHeight, (int)position.y);
		}

		maxWidth++; maxDepth++; maxHeight++;
		shape.width = maxWidth; shape.depth = maxDepth; shape.height = maxHeight;
		bool[] shapeArray = new bool[maxWidth * maxHeight * maxDepth];

		foreach (Transform childTransform in this.transform)
		{
			Vector3 position = childTransform.localPosition;
			int x = (int)position.x;
			int y = (int)position.y;
			int z = (int)position.z;
			// http://stackoverflow.com/questions/7367770/how-to-flatten-or-index-3d-array-in-1d-array
			shapeArray[x + maxWidth * (y + maxHeight * z)] = true;
		}

		shape.blocks = shapeArray;

		return shape;
	}
}
