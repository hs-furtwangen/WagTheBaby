using UnityEngine;

using System.Collections;

public class PlayWithObject : MonoBehaviour {

	GameObject toy; 
	public GameObject PlaceHolder;
	Vector2 oldMousePos = Vector2.zero;
	float impulse = 5;
	float sensitivity = 1f;
	//MouseLook mouseLook = GetComponent<MouseLook>();
	// Use this for initialization
	void Start () {
	
		toy = null;
		//mouseLook = GetComponent<MouseLook>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 4))
			{
				if(hit.rigidbody != null)
				{
					toy = hit.rigidbody.gameObject;

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
			impulse = Mathf.Abs (toy.transform.rotation.x)*10;

			toy.rigidbody.AddForce(transform.forward*impulse, ForceMode.Impulse);
			toy = null;
		}
	}

}
