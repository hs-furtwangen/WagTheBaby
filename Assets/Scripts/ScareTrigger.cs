using UnityEngine;
using System.Collections;

public class ScareTrigger : MonoBehaviour {

	// Scaretrigger APPLY TO FPController

	public GameObject scareTrigger = null;
	public float scareRadius = 1.0f;
	public float rotationSpeed = 10.0f;

	void Start() {
		if(!scareTrigger) {
			Application.Quit();
			return;
		}

		// Hide all Scareplanes
		foreach(Transform t in scareTrigger.transform) {
			foreach(Transform b in t) {
				b.GetComponent<MeshRenderer>().enabled = false;
			}
		}

	}

	void LateUpdate()  {
		foreach(Transform t in scareTrigger.transform) {
			//bool isRotating = t.GetComponent<isRotatingUp>().isRotating;
			bool isRotating = t.GetComponent<isRotatingUp>().isRotating;
			// Rotate about 90° up to make visible
			if(isRotating) {
				if(t.localEulerAngles.x >= -90.0f) {
					//t.localEulerAngles -= new Vector3(rotationSpeed, 0, 0);
					t.localRotation = Quaternion.Lerp(t.localRotation, Quaternion.Euler(-90, t.localRotation.eulerAngles.y, t.localRotation.eulerAngles.z), Time.deltaTime * rotationSpeed);
				}
			}

			if(Vector3.Distance(t.position, this.transform.position) <= 1 && !isRotating) {
				// activate Meshrenderer
				foreach(Transform b in t) {
					b.GetComponent<MeshRenderer>().enabled = true;
				}
				if(t.GetComponent<isRotatingUp>().isLooking) {
					t.LookAt(this.transform);
					t.localEulerAngles = new Vector3(0, t.localEulerAngles.y * -1, 0);
				}
				// Set Flag to Rotate up
				t.GetComponent<isRotatingUp>().isRotating = true;

				// playsound
				if(t.GetComponent<AudioSource>()) {
					t.GetComponent<AudioSource>().Play();
				}
			}
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(this.transform.position, scareRadius);
	}
}
