using UnityEngine;


public class DistanceChecking : MonoBehaviour 
{
			
	public GameObject RealPrefab;
	public GameObject EvilPrefab;
	private MeshCollider _col;
	// Use this for initialization
	void Start () 
	{
		Instantiate(RealPrefab, transform.position, transform.rotation);
	}
			
	// Update is called once per frame
	void Update () {
	
	}
			
	void OnTriggerEnter()
	{
		Instantiate(EvilPrefab, RealPrefab.transform.position, RealPrefab.transform.rotation);
		Destroy(RealPrefab);
	}
			
	void OnTriggerExit()
	{
		Instantiate(RealPrefab, transform.position, transform.rotation);
		Destroy(EvilPrefab);
	}
}