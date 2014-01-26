using UnityEngine;

using System.Collections;

public class PlayWithObject : MonoBehaviour {

	GameObject toy; 
	GameObject PlaceHolder;
	GameObject SlingShot;
	GameObject SlingShotHolder;
	public GameObject Projectile;
	bool slingActive;
	bool sling;
	private bool hasKey = false;

	Vector2 oldMousePos = Vector2.zero;
	float impulse = 5;
	float sensitivity = 1f;
	//MouseLook mouseLook = GetComponent<MouseLook>();
	// Use this for initialization
	void Start () {
	
		SlingShot = null;
		slingActive = false;
		sling = false;
		SlingShotHolder = GameObject.Find("SlingShotPlace");

		toy = null;
		PlaceHolder = GameObject.Find("PlaceHolder");
		//mouseLook = GetComponent<MouseLook>();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.E) && sling)
		{
			if (!slingActive)
			{
				slingActive = true;
				SlingShot.renderer.enabled = true;
			}
			else
			{
				slingActive = false;
				SlingShot.renderer.enabled = false;
			}
		}

		if(Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, 0.2f)) {
				if(hit.collider && hasKey) {
					if(hit.collider.gameObject.tag == "Klinke") {
						Debug.Log("WIN");
						GameStateHandler.CurrentGameState = (int)GameState.GameWin;
					}
				}
			}

			if (Physics.Raycast(ray, out hit, 2))
			{
				if(hit.collider.tag == "Key") {
					Debug.Log("KeyPick");
					GameObject key = hit.collider.gameObject;
					key.GetComponent<BoxCollider>().enabled = false;
					key.GetComponent<MeshRenderer>().enabled = false;
					hasKey = true;
				}

				if(hit.rigidbody != null)
				{
					if(sling && slingActive)
					{
						Debug.Log("schießen");
					}
					else
					{
						if(hit.rigidbody.tag == "slingshot")
						{
							Debug.Log("Added Slingshot");
							SlingShot = hit.rigidbody.gameObject;
							SlingShot.GetComponent<BoxCollider>().enabled = false;
							SlingShot.collider.enabled = false;
							SlingShot.rigidbody.isKinematic = true;
							SlingShot.rigidbody.useGravity = false;
							SlingShot.transform.parent = transform;
							SlingShot.transform.position = SlingShotHolder.transform.position;
							SlingShot.transform.rotation = SlingShotHolder.transform.rotation;
							slingActive = true;
							sling = true;

						}
						else
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
			}

		}
	


	}

	void FixedUpdate()
	{
		if(Input.GetMouseButtonUp(0) && toy != null)
		{
			toy.transform.parent = null;
			toy.rigidbody.isKinematic = false;
			toy.collider.enabled = true;
			toy.rigidbody.AddForce(transform.forward*impulse, ForceMode.Impulse);
			
			toy = null;
		}

		if(Input.GetButtonDown("Fire1") && slingActive)
		{
			Instantiate(Projectile, SlingShotHolder.transform.position+transform.up*0.28f, transform.rotation);
		}
	}
}
