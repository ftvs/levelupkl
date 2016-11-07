using UnityEngine;
using System.Collections;

public class MouseDraggable : MonoBehaviour {
	public Vector3 mousePosition;
	public Vector3 screenToWorldPoint;
	public Camera _mainCamera;

	protected Camera MainCamera {
		get {
			if (_mainCamera == null) {
				_mainCamera = Camera.main;
			}

			return _mainCamera;
		}
	}

	void Start()
	{
		_mainCamera = Camera.main;
	}

	void OnMouseDrag()
	{
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		point.z = gameObject.transform.position.z;
		point.y = gameObject.transform.position.y;
		gameObject.transform.position = point;

		screenToWorldPoint = point;
	}

	void Update()
	{
//		if (Input.GetButtonDown("Fire1"))
//		screenToWorldPoint = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

		mousePosition = Input.mousePosition;
	}

	void OnMouseDrag()
	{
		float distance_to_screen = MainCamera.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 pos_move = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
		transform.position = new Vector3( pos_move.x, transform.position.y, pos_move.z );

	}
}
