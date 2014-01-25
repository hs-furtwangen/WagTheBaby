using UnityEngine;
using System.Collections;

public class DestroyEvil : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit()
	{
		Debug.Log("Exit");
		SendMessageUpwards("ChangeInstance", this.gameObject);
	}
}
