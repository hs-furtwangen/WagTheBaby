using UnityEngine;

public class ImpactShaderController : MonoBehaviour
{

    public Transform PlayerPosition;

	// Use this for initialization
    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
	void Update ()
    {
        renderer.material.SetVector("_centerPos", PlayerPosition.position);
	}
}
