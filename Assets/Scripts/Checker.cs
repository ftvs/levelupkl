using UnityEngine;
using System.Collections;

public class Checker : MonoBehaviour {
	public bool cube;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	[ExecuteInEditMode]
	void OnTriggerStay(Collider other) {
		if (other) {
			cube = true;
		} else {
			cube = false;
		}
	}
}
