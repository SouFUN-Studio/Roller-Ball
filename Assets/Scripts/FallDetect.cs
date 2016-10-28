using UnityEngine;
using System.Collections;

public class FallDetect : MonoBehaviour {

    Vector3 checkpoint;
	// Use this for initialization
	void Start () {
        checkpoint = new Vector3(0.0f, 0.5f, 0.0f); 
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y <= -10)
        {
            transform.position = checkpoint;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 0.0f)*0.0f);
            gameObject.GetComponent<Rigidbody>().Sleep();
        }
	
	}
}
