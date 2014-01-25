using UnityEngine;
using System.Collections;

public class LavaParticle : MonoBehaviour {

	public GameObject fpController = null;
	private AudioSource hiss = null;
	public GameObject lavafloor = null;
	private float timer = 5.0f;

	// Use this for initialization
	void Start () {
		if(fpController == null) return;
		if(lavafloor == null) {
			Debug.Log("Assign Lavafloor Gameobject");
			return;
		}
		hiss = this.transform.gameObject.GetComponentInChildren<AudioSource>();
		if(hiss == null) Debug.Log ("No Audisource for his available as child");
	}
	
	// Update is called once per frame
	void Update () {
		if(fpController == null || lavafloor == null) return;
		this.transform.position = new Vector3(fpController.transform.position.x, this.transform.position.y, fpController.transform.position.z);

		if(hiss && lavafloor) {
			timer -= Time.deltaTime;
			if(timer <= 0.0f) {
				hiss.transform.localPosition = Random.insideUnitCircle * lavafloor.renderer.material.GetFloat("_Radius1");
				timer += Random.Range(5.0f, 10.0f);
				hiss.Play();
			}
		}
	}
}
