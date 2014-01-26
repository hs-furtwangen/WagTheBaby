using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

	public Texture GlassCracked;
	public Texture GlassBroken;
	public GameObject boden;
	public GameObject Wind;
	bool startWind;
	float timer = 0;
	// Use this for initialization
	void Start () {
		boden = GameObject.Find("RepbuildRaum/Raum/Boden_1");
		this.renderer.material.mainTexture = GlassCracked;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(startWind)
		{
			timer += Time.deltaTime;

			if(timer > 5.0f)
			{
				Debug.Log("Time over");
				
				//Wind.SetActive(false);
				//Destroy(Wind.gameObject);
				GameObject w = GameObject.Find("WindZone(Clone)");
				Destroy(w.gameObject);
				//Wind.transform.position = new Vector3(0,-500,0);
				startWind = false;

				boden.renderer.material.color = Color.cyan;

			}
		}



	}


	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "projectile")
		{
			Debug.Log("fenster getroffen");
			this.renderer.material.mainTexture = GlassBroken;
			this.collider.enabled = false;
			startWind = true;
			Instantiate(Wind, transform.position + Vector3.right * 2, Quaternion.Euler(new Vector3(30,270,0)));
			//boden -> eis
		}
	}
}
