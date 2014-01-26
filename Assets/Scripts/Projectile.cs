using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


	float timer = 0;
	// Use this for initialization
	void Start () 
	{
		rigidbody.AddForce(transform.forward*8, ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer > 2)
		{
			//Debug.Log("time over");
			Destroy(this.gameObject);
		}
	}


}
