using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;
    public Text countText;
    public Text winText;
    public bool grounded = false;   

    private Rigidbody rb;
    private int count;

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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
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
