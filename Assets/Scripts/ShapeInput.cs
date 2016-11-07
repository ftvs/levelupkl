using UnityEngine;
using System.Collections;

//Considerations:
/*
1. Boundaries from 0 to x and 0 to y
2. Move a constant 1 for x, y, z
3. Way to handle input for z (for this case, z = x)
TODO: Because of the way this will work, create a way to move the mouse around
*/

public class ShapeInput : MonoBehaviour
{
    Vector3 startPos;
    Vector3 prevMousePos;

    bool clicked = false;

    Camera main;
    RaycastHit hit;

    void Start()
    {
        main = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            bool hasRaycast = Physics.Raycast(ray, out hit);
            bool correctObject = false;

            if (hit.transform != null) // if hit this transform gameobject
                correctObject = hit.transform.gameObject == transform.gameObject;

//			if (Debug.isDebugBuild) {
//				Debug.Log("button down. raycast " + hasRaycast + " hit this object " + correctObject + " hasselected " + GameMgr.Instance.HasSelected());
//			}
            if (hasRaycast && correctObject && !GameMgr.Instance.HasSelected())
            {
                prevMousePos = Input.mousePosition;

                GameMgr.Instance.SetSelected(true);
                parentTransform = hit.transform.parent;
                clicked = hit.transform.gameObject == transform.gameObject;
                prevMousePos = Input.mousePosition;
				if (Debug.isDebugBuild) {
					Debug.Log("selected " + GameMgr.Instance.HasSelected() + " ");
				}
            }
        }
        else if (clicked && GameMgr.Instance.HasSelected())
        {
            MouseDragHandler();
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) && GameMgr.Instance.HasSelected())
        {
            clicked = false;
            GameMgr.Instance.SetSelected(false);
        }
    }

    Transform parentTransform;

    void MouseDragHandler()
    {
        float xDiff = Mathf.Abs(Input.mousePosition.x - prevMousePos.x);
        float yDiff = Mathf.Abs(Input.mousePosition.y - prevMousePos.y);
        float xMult = Input.mousePosition.x > prevMousePos.x ? 1 : -1;
        float yMult = Input.mousePosition.y > prevMousePos.y ? 1 : -1;

        if (Input.GetMouseButton(1))
        {
//            Debug.Log("right click");

            //check for bounds
            if (xDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                if (withinBounds(parentTransform))
                {
                    parentTransform.localPosition = new Vector3(parentTransform.localPosition.x, parentTransform.localPosition.y, parentTransform.localPosition.z + xMult*GameMgr.Instance.GRID_SIZE);
                    prevMousePos = Input.mousePosition;
                }
            }
            else if (yDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                if (withinBounds(parentTransform))
                {
                    parentTransform.localPosition = new Vector3(parentTransform.localPosition.x, parentTransform.localPosition.y, parentTransform.localPosition.z + yMult*GameMgr.Instance.GRID_SIZE);
                    prevMousePos = Input.mousePosition;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Debug.Log("left click");
            Debug.Log(xDiff >= GameMgr.Instance.MOUSE_THRESHOLD);
            if (xDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                if (withinBounds(parentTransform))
                {
                    parentTransform.localPosition = new Vector3(parentTransform.localPosition.x+xMult*GameMgr.Instance.GRID_SIZE, parentTransform.localPosition.y, parentTransform.localPosition.z);
                    prevMousePos = Input.mousePosition;
                }
            }
            if (yDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                if (withinBounds(parentTransform))
                {
                    parentTransform.localPosition = new Vector3(parentTransform.localPosition.x, parentTransform.localPosition.y+yMult*GameMgr.Instance.GRID_SIZE, parentTransform.localPosition.z);
                    prevMousePos = Input.mousePosition;
                }
            }
        }
    }

    bool withinBounds(Transform t)
    {
        //check if within bounds in the world
        //TODO: check if intersecting in the next move
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            if (r != GetComponent<Renderer>())
            {
            
            }
        }
        return true;
    }
}