using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 5f;
    private int index;
    private int direction = 1;
    private Transform playerOnPlatform;
    private Vector3 lastPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[index].position) < 0.1f)
        {
            if (index == points.Length - 1)
            {
                direction = -1;
            }
            else if (index == 0)
            {
                direction = 1;
            }

            index += direction;
        }

       

        transform.position = Vector2.MoveTowards(transform.position, points[index].position, moveSpeed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = null;
        }
    }


    void LateUpdate()
    {
        Vector3 delta = transform.position - lastPosition;

        if (playerOnPlatform != null)
        {
            playerOnPlatform.position += delta;
        }
        lastPosition = transform.position;
    }



}



