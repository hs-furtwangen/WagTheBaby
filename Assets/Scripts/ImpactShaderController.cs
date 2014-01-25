using UnityEngine;
using System.Collections;

public class ImpactShaderController : MonoBehaviour
{

    public Transform playerPosition;

	// Use this for initialization
	void Start ()
	{
	    //playerPosition = GameObject.Find("/Plane");
	}
	
	// Update is called once per frame
	void Update () {
        renderer.material.SetVector("_centerPos", new Vector3(playerPosition.position.x, 0, playerPosition.position.z));
        Debug.Log(playerPosition.position);
	}
}
