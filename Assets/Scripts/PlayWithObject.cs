using UnityEngine;

using System.Collections;

public class PlayWithObject : MonoBehaviour {

	GameObject toy; 
	GameObject PlaceHolder;
	Vector2 oldMousePos = Vector2.zero;
	float impulse = 5;
	float sensitivity = 1f;
	//MouseLook mouseLook = GetComponent<MouseLook>();
	// Use this for initialization
	void Start () {
	
		toy = null;
		PlaceHolder = GameObject.Find("PlaceHolder");
		//mouseLook = GetComponent<MouseLook>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 2))
			{
				if(hit.rigidbody != null)
				{
					toy = hit.rigidbody.gameObject;
					toy.collider.enabled = false;
					toy.rigidbody.isKinematic = true;
					toy.transform.parent = transform;
					toy.transform.position = PlaceHolder.transform.position;

					toy.transform.rotation =  PlaceHolder.transform.rotation;
				}
			}
		}

		if(Input.GetMouseButtonUp(0) && toy != null)
		{
			toy.transform.parent = null;
			toy.rigidbody.isKinematic = false;
			toy.collider.enabled = true;

			Debug.Log("direction: " + toy.transform.forward*5);
			toy.rigidbody.AddForce(transform.forward*impulse, ForceMode.Impulse);

			toy = null;
		}
	}

}
