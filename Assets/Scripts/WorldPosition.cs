using UnityEngine;
using System.Collections;

public class WorldPosition : MonoBehaviour {
	public Vector3 worldPos;

	// Update is called once per frame
	void Update () {
		worldPos = transform.position;
	}
}
