using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public bool active;
	// Use this for initialization
	void Start () 
	{
		active = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(active == false)
			{
				active = true;
			}
			else
			{
				active = false;
			}
		}
	}
}
