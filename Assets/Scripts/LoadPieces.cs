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

		int distanceBetweenPieces = 5;
		int i = 0;

		foreach (Object pieceObj in pieces)
		{
			GameObject piece = Instantiate(pieceObj) as GameObject;
			piece.transform.parent = this.transform;
			Vector3 pos = piece.transform.localPosition;
			piece.transform.localPosition = new Vector3(-7, 0 + (i * distanceBetweenPieces), pos.z);

			i++;
		}

//		GameObject piece = Instantiate() as GameObject;

		this.enabled = false;
	}
}
