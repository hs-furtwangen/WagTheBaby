using UnityEngine;
using System.Collections;

public class Impact : MonoBehaviour {
	
	Vector3 point;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetVector("_BrighteningPos", point);
	}

	void OnCollisionEnter(Collision collision)
	{
		point = collision.contacts[0].point;
	}

}
