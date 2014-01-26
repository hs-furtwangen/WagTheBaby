using UnityEngine;
using System.Collections;

public class OpenDoors : MonoBehaviour {

	void FixedUpdate () 
	{
		/*
 		 *  Türen aufmachen
		 */
		if(Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 2)) {
				if(hit.collider.gameObject.tag == "clickableDoors") {
					Animation a = hit.collider.gameObject.transform.parent.GetComponent<Animation>();
					if(!a.isPlaying && !hit.collider.gameObject.GetComponent<DoorFlag>().isOpen) {
						hit.collider.gameObject.GetComponent<DoorFlag>().isOpen = true;
						hit.collider.gameObject.transform.parent.GetComponent<AudioSource>().Play();
						a.Play();
					}
				}
			}
		}
	}
}
