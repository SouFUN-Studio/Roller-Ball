using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public Text countText;
    public Text winText;
    public bool grounded = false;   

    private Rigidbody rb;
    private int count;
    private float brk = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        while (rb.velocity.x != 0.0f && rb.velocity.z != 0.0f)
        {
            if (grounded && Input.GetButtonDown("Fire1"))
                rb.AddForce(new Vector3(rb.velocity.x, 0.0f, rb.velocity.z) * brk);
        }
    }
    void OnCollisionStay()
    {
        grounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionExit()
    {
        grounded = false;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "YOU WIN!!";
        }
    }
}
