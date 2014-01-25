using UnityEngine;
using System.Collections;



public class DistanceChecking : MonoBehaviour 
{
			
	public GameObject RealPrefab;
	public GameObject EvilPrefab;
	private MeshCollider col;
	// Use this for initialization
	void Start () 
	{
		Destroy(GetComponent<Collider>());
		col = gameObject.AddComponent("MeshCollider") as MeshCollider;
	
		this.GetComponent<MeshFilter>().mesh = RealPrefab.GetComponent<MeshFilter>().mesh;
		//this.GetComponent<Collider>().collider = RealPrefab.GetComponent<Collider>().collider;

	}
			
	// Update is called once per frame
	void Update () {
	
	}
			
	void OnTriggerEnter(Collider other)
	{
		this.GetComponent<MeshFilter>().mesh = EvilPrefab.GetComponent<MeshFilter>().mesh;
		//this.GetComponent<Collider>().collider = EvilPrefab.GetComponent<Collider>().collider;
	}
			
	void OnTriggerExit(Collider other)
	{
		this.GetComponent<MeshFilter>().mesh = RealPrefab.GetComponent<MeshFilter>().mesh;
		//this.GetComponent<Collider>().collider = RealPrefab.GetComponent<Collider>().collider;
	}
}