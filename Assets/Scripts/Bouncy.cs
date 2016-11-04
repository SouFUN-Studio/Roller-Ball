using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {

    bool bouncy = false;
    float bounceAmount = 10.0f;
    Transform player;
	
	// Update is called once per frame
	void Update () {
        if (bouncy)
        {
           // player.GetComponent<Rigidbody>().velocity.y = 0.0f;
        }
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            bouncy = true;
        }
    }
}
