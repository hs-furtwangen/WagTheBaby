using UnityEngine;
using System.Collections;

public class DestroyReal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter()
	{
		Debug.Log("Enter");
		SendMessageUpwards("ChangeInstance", this.gameObject);
	}

}
