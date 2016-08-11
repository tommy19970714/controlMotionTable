using UnityEngine;
using System.Collections;

public class LimitY : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 10.0f), transform.position.z);

	}
}
