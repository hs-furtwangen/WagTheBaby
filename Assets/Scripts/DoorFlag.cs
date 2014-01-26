using UnityEngine;
using System.Collections;

public class DoorFlag : MonoBehaviour {
	private bool _isOpen = false;
	public bool isOpen {
		get { return _isOpen; }
		set { _isOpen = value; }
	}
}
