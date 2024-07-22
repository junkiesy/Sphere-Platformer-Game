using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Store initial position
    }

    void Update()
    {
        Move();
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Vertical") * moveSpeed;
        float moveZ = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveX, rb.velocity.y, -moveZ);

        rb.velocity = movement;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void ResetPlayer()
    {
        transform.position = startPosition; 
        rb.velocity = Vector3.zero;
    }
}
