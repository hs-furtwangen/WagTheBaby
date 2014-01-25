using UnityEngine;
using System.Collections;

public class colTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.
		renderer.material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collisionInfo)
	{
		if(collisionInfo.gameObject.tag == "Player")
		{
			renderer.material.color = Color.blue;
		}
	}

}
