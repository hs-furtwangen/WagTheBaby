using UnityEngine;
using System.Collections;

public class ImpactShaderController : MonoBehaviour
{

    public Transform playerPosition;

	// Use this for initialization
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
	void Update ()
    {
        renderer.material.SetVector("_centerPos", playerPosition.position);
	}
}
