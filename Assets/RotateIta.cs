using UnityEngine;
using System.Collections;

public class RotateIta : MonoBehaviour {

	public GameObject sensor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (sensor.transform.rotation.x > transform.rotation.x)
		{
			transform.Rotate (1, 0, 0);
		}
		if (sensor.transform.rotation.x < transform.rotation.x)
		{
			transform.Rotate (-1, 0, 0);
		}
		if (sensor.transform.rotation.y > transform.rotation.y)
		{
			transform.Rotate (0, 1, 0);
		}
		if (sensor.transform.rotation.y < transform.rotation.y)
		{
			transform.Rotate (0, -1, 0);
		}
		if (sensor.transform.rotation.z > transform.rotation.z)
		{
			transform.Rotate (0, 0, 1);
		}
		if (sensor.transform.rotation.z > transform.rotation.z)
		{
			transform.Rotate (0, 0, -1);
		}

	}
}
