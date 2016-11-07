using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {
	public float X;
	public float y;
	public GameObject Cube;
	public Transform Head;
	public GameObject CL;
	public GameObject CM;
	public GameObject CR;
	public Transform paret;
	public GameObject[] Cubes;
	// Use this for initialization
	[ContextMenu("get cubes")]

	void getCubes () {
		Cubes = GameObject.FindGameObjectsWithTag ("cube");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[ContextMenu("Mirror")]
	void Mir(){
		Head.localPosition = Vector3.zero;
		for (int i = 0; i <= X; i++) {
			for (int j = 0; j <= y; j++) {
				foreach (GameObject cuu in Cubes) {
					if (Head.localPosition == cuu.transform.localPosition) {
						Vector3 newpose = new Vector3 (CL.transform.localPosition.x * -1, CL.transform.localPosition.y, CL.transform.localPosition.z);
						GameObject Q = Instantiate (Cube,newpose, CL.transform.rotation)as GameObject;
						Q.transform.parent = paret;
						Q.transform.localPosition = newpose;

						Vector3 newposee = new Vector3 (CM.transform.localPosition.x * -1, CM.transform.localPosition.y, CM.transform.localPosition.z);
						GameObject Qe = Instantiate (Cube,newposee, CM.transform.rotation)as GameObject;
						Qe.transform.parent = paret;
						Qe.transform.localPosition = newposee;
						Vector3 newposeee = new Vector3 (CR.transform.localPosition.x * -1, CR.transform.localPosition.y, CR.transform.localPosition.z);
						GameObject Qee = Instantiate (Cube,newposeee, CR.transform.rotation)as GameObject;
						Qee.transform.parent = paret;
						Qee.transform.localPosition = newposeee;
					



					}
				}


				Head.transform.localPosition = new Vector3 (0, -j / 2f, -i/2f);
				print (i.ToString () + j.ToString ());
			}
		}
	}
}
