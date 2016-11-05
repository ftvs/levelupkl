using UnityEngine;
using System.Collections;

public class CheckSolution : MonoBehaviour {
	public TextAsset solution;
	public SaveShapeToJson saveShapeToJson;

	void OnEnable()
	{
		Shape shape = saveShapeToJson.ObjectsToShape();

		if (Debug.isDebugBuild) {
			Debug.Log("equals: " + JsonUtility.ToJson(shape).Equals(solution.text));
		}

		this.enabled = false;
	}
}
