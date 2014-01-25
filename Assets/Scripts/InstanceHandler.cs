﻿using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class InstanceHandler : MonoBehaviour {

    private Dictionary<GameObject, GameObject> instanceDict = new Dictionary<GameObject, GameObject>();

	// Use this for initialization
	void Start () {
        instanceDict.Add((GameObject) Resources.Load("Cube", typeof(GameObject)), (GameObject) Resources.Load("Sphere", typeof(GameObject)));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeInstance(GameObject go)
    {
        foreach (KeyValuePair<GameObject, GameObject> pair in instanceDict)
        {
            if (pair.Key.name == go.name)
            {
                GameObject newGameObject = (GameObject) Instantiate(pair.Value, pair.Value.transform.position, pair.Value.transform.rotation);
                newGameObject.transform.parent = go.transform.parent;
                Destroy(go);
            }
            else if (pair.Value.name == go.name)
            {
                GameObject newGameObject = (GameObject)Instantiate(pair.Key, pair.Key.transform.position, pair.Key.transform.rotation);
                newGameObject.transform.parent = go.transform.parent;
                Destroy(go);
            }
        }
    }

}
