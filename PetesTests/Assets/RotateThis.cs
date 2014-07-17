using UnityEngine;
using System.Collections;

public class RotateThis : MonoBehaviour {
	public Vector3 RotateBy;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (RotateBy);
	}
}
