using UnityEngine;

using System.Collections;

public class PlayWithObject : MonoBehaviour {

	GameObject toy; 
	Vector2 oldMousePos = Vector2.zero;
	float sensitivity = 0.5f;
	// Use this for initialization
	void Start () {
	
		toy = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			//RaycastHit zum Object
			//Debug.Log("LeftMousClik");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if(hit.rigidbody != null)
				{
					toy = hit.rigidbody.gameObject;

					toy.rigidbody.useGravity = false;
					toy.rigidbody.isKinematic = true;
					Debug.Log("once");
				}
			}
		}

		if(Input.GetMouseButtonUp(0) && toy != null)
		{
			toy.rigidbody.useGravity = true;
			toy.rigidbody.isKinematic = false;
			toy.rigidbody.AddForce(new Vector3(0,0,5), ForceMode.Impulse);
			toy = null;
		}
		if(toy != null)
		{
			Vector2 currentMousePos = new Vector2(-Input.GetAxis("Mouse X") * sensitivity, -Input.GetAxis("Mouse Y")* sensitivity );
			Vector2 delta = new Vector2(oldMousePos.x-currentMousePos.x, oldMousePos.y-currentMousePos.y);
			toy.transform.position = new Vector3(toy.transform.position.x + delta.x, toy.transform.position.y + delta.y, 6);
			oldMousePos = Vector2.zero;
		}
	}

}
