using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public float stopXPosition = 40f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.x < stopXPosition)
        {
            MoveForward();
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0); 
        }
    }

    void MoveForward()
    {
        Vector3 movement = new Vector3(moveSpeed, rb.velocity.y, 0);
        rb.velocity = movement;
    }

    void JumpForward()
    {
        Vector3 jump = new Vector3(moveSpeed, jumpForce, 0);
        rb.AddForce(jump, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && transform.position.x < stopXPosition)
        {
            isGrounded = true;
            JumpForward();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
