using UnityEngine;
using System.Collections;

public class LoadPieces : MonoBehaviour {
	public string levelFolderName;

	void OnEnable()
	{
		Object[] pieces = Resources.LoadAll("Prefabs/" + levelFolderName);

		foreach (Object pieceObj in pieces)
		{
			GameObject piece = Instantiate(pieceObj) as GameObject;
		}

//		GameObject piece = Instantiate() as GameObject;

		this.enabled = false;
	}
}
