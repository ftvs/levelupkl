using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PubSub;

public class GameMgr : MonoBehaviour
{
	static GameMgr _instance;
	private PubSubBroker _pubsubMgr = new PubSubBroker();

    private bool hasSelected = false;

    //HACK: PUBLIC ALL THE THINGS lol
    public float MOUSE_THRESHOLD = 100f; //how much the mouse (or finger, eventually) has to move before being responsive
    public float GRID_SIZE = 1.00f; //movement of a puzzle piece, equivalent to the size of a single block
    public float ROTATION = 45.00f;
    public float STARTING_ROTATION = 0f;
    public List<GameObject> pieces = new List<GameObject>();
    public float currentRotation = 0f;

    public Bounds worldBounds;

    private int rotationPositive = 1;
    void Update()
    {
        if (Input.GetButtonDown("Rotate"))
        {   
            float currentRot = pieces[0].transform.rotation.eulerAngles.y;
            if (Mathf.Approximately(currentRot, 180.0f))
            {
                rotationPositive = -1;
            }
            else if (Mathf.Approximately(currentRot, 0f))
            {
                rotationPositive = 1;
            }

            foreach (GameObject p in pieces)
            {
                Debug.Log("rotate! "+p);
                p.transform.Rotate(0f, ROTATION*rotationPositive, 0);
            }
            currentRotation += ROTATION*rotationPositive;
        }
    }

	void OnEnable ()
    {
        currentRotation = STARTING_ROTATION;
        worldBounds = new Bounds(new Vector3(15f, 15f, 15f), new Vector3(15f, 15f, 15f));
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(_instance);
		}
	}
	
	public PubSubBroker GetPubSubBroker()
    {
		return _pubsubMgr;
	}

    public bool HasSelected()
    {
        return hasSelected;
    }
    public void SetSelected(bool s)
    {
        hasSelected = s;
    }

	static public GameMgr Instance
    {
		get { return _instance; }
	}
}