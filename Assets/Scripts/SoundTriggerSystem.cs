using UnityEngine;
using System.Collections;

public class SoundTriggerSystem : MonoBehaviour {

	// AND THIS SCRIPT TO YOUR CHARACTERCONTROLLER OR SIMLILAR TO ITS POSITION
	public GameObject triggerObjects = null;
	public float radius = 3.0f;


	void Start () 
	{
		if(triggerObjects == null) {Application.Quit(); return;}
	}

	void Update () 
	{
		foreach(Transform t in triggerObjects.transform) {
			//Debug.Log(t.gameObject.name);
			if(Vector3.Distance(t.position, this.transform.position) <= radius) {
				t.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, radius);
	}
}
