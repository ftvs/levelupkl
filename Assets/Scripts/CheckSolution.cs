using UnityEngine;
using System.Collections;

public class CheckSolution : MonoBehaviour {
	public TextAsset solution;
	public SaveShapeToJson saveShapeToJson;

	void OnEnable()
	{
		Shape solutionShape = JsonUtility.FromJson<Shape>(solution.text);
		Shape shape = saveShapeToJson.ObjectsToWorldPositionShape();

		if (Debug.isDebugBuild) {
			Debug.Log("equals: " + solutionShape.Equals(shape));
		}

		this.enabled = false;
	}
}
