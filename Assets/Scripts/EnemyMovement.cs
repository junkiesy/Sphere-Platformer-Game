using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 2f;
    private Vector3 startPos;
    private bool movingForward = true;
    private GameResetManager gameResetManager;

    void Start()
    {
        startPos = transform.position;
        gameResetManager = FindObjectOfType<GameResetManager>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (movingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= startPos.z + range)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            if (transform.position.z <= startPos.z - range)
            {
                movingForward = true;
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = startPos;
        movingForward = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameResetManager.ResetGame();
        }
    }
}
