using UnityEngine;

public class LavaCollision : MonoBehaviour
{

    private Vector3 RespawnPosition = new Vector3(0.5f, 1f, 0f);
    private float raylength = 0.35f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raylength ))
        {
            if (hit.transform.tag == "Respawn" && GameStateHandler.CurrentGameState == (int) GameState.RunningLava)
            {
               transform.position = RespawnPosition;
            }
        }
	}
}
