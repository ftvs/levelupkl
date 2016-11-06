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
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == transform.gameObject)
            {
                prevMousePos = Input.mousePosition;

                clicked = hit.transform.gameObject == transform.gameObject;
                prevMousePos = Input.mousePosition;
            }
        }
        else if (clicked)
        {
            MouseDragHandler();
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            clicked = false;
        }
    }

    void MouseDragHandler()
    {
        float xDiff = Mathf.Abs(Input.mousePosition.x - prevMousePos.x);
        float yDiff = Mathf.Abs(Input.mousePosition.y - prevMousePos.y);
        float xMult = Input.mousePosition.x > prevMousePos.x ? 1 : -1;
        float yMult = Input.mousePosition.y > prevMousePos.y ? 1 : -1;
        Debug.Log(Input.GetMouseButton(0));
        Debug.Log(Input.GetMouseButton(1));

        Debug.Log(Input.mousePosition);
        Debug.Log(prevMousePos);

        if (Input.GetMouseButton(1))
        {
            Debug.Log("right click");

            if (xDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + xMult*GameMgr.Instance.GRID_SIZE);
                prevMousePos = Input.mousePosition;
            }
            else if (yDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + yMult*GameMgr.Instance.GRID_SIZE);
                prevMousePos = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Debug.Log("left click");
            Debug.Log(xDiff >= GameMgr.Instance.MOUSE_THRESHOLD);
            if (xDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                transform.position = new Vector3(transform.position.x+xMult*GameMgr.Instance.GRID_SIZE, transform.position.y, transform.position.z);
                Debug.Log("oops");
                prevMousePos = Input.mousePosition;
            }
            if (yDiff >= GameMgr.Instance.MOUSE_THRESHOLD)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y+yMult*GameMgr.Instance.GRID_SIZE, transform.position.z);
                prevMousePos = Input.mousePosition;
            }
        }
    }
}