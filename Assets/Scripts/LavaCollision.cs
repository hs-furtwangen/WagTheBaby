using UnityEngine;

public class LavaCollision : MonoBehaviour
{

    private Vector3 RespawnPosition = new Vector3(1.97f, 1.81f, -6.14f);
	private Vector3 RespawnRotation = new Vector3(7.94f, 129.7f, 0f);
    private float raylength = 0.35f;

	private float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
		timer += Time.deltaTime;
		if(timer <= 1.4f) {
			GameObject.Find("First Person Controller").GetComponent<CharacterController>().enabled = false;
		} else {
			GameObject.Find("First Person Controller").GetComponent<CharacterController>().enabled = true;
		}
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raylength ))
        {
            if (hit.transform.tag == "Respawn" && GameStateHandler.CurrentGameState == (int) GameState.RunningLava)
            {
				timer = 0.0f;
				transform.position = RespawnPosition;
            }
        }
	}
}
