using UnityEngine;
using System.Collections;

public class LoadPieces : MonoBehaviour {
	public string levelFolderName;

	private Transform _transform;

	protected Transform MyTransform {
		get {
			if (_transform == null) {
				_transform = transform;
			}
			
			return _transform;
		}
	}

	void OnEnable()
	{
		Object[] pieces = Resources.LoadAll("Prefabs/" + levelFolderName);

		int distanceBetweenPieces = 3;
		int i = 0;

		foreach (Object pieceObj in pieces)
		{
			GameObject piece = Instantiate(pieceObj) as GameObject;
			piece.transform.parent = Camera.main.transform;
			Vector3 pos = piece.transform.localPosition;
			piece.transform.localPosition = new Vector3(-7, pos.y + (i * distanceBetweenPieces), pos.z);

			i++;
		}

//		GameObject piece = Instantiate() as GameObject;

		this.enabled = false;
	}
}
