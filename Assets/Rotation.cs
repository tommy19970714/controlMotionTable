using UnityEngine;
using System.Collections;



public class Rotation : MonoBehaviour
{
	private Vector3 rot = new Vector3(0,0,0);	

//	0.2325
//	89.9981
//	359.0272
    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        float spd = Time.deltaTime * 100.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
			rot.y -= spd;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
			rot.y += spd;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rot.x -= spd;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rot.x += spd;
        }
//		transform.Rotate(rot);
        transform.rotation = Quaternion.Euler(rot);
    }
}
