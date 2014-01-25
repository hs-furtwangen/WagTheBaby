using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class InstanceHandler : MonoBehaviour {

    public Dictionary<GameObject, GameObject> instanceDict = new Dictionary<GameObject, GameObject>();

	// Use this for initialization
	void Start () {
		instanceDict.Add((GameObject) Resources.Load<GameObject>("Cube"), (GameObject) Resources.Load<GameObject>("Sphere"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeInstance(GameObject go)
    {
        foreach (KeyValuePair<GameObject, GameObject> pair in instanceDict)
        {
			if (pair.Key.name == go.name || pair.Key.name + "(Clone)" == go.name)
            {
				Debug.Log("ChangeIstanceExit");
				GameObject newGameObject = (GameObject) Instantiate(pair.Value, go.transform.position, go.transform.rotation);
                newGameObject.transform.parent = go.transform.parent;
                Destroy(go);
            }
			else if (pair.Value.name == go.name || pair.Value.name + "(Clone)" == go.name)
            {
				Debug.Log("ChangeIstanceEnter");
				GameObject newGameObject = (GameObject)Instantiate(pair.Key, go.transform.position, go.transform.rotation);
                newGameObject.transform.parent = go.transform.parent;
                Destroy(go);
            }
        }
    }

}
