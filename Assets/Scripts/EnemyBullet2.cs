using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;              // Adjustable in Inspector
    [SerializeField] private Vector2 direction = Vector2.up; // Default direction is "up"

    private Vector3 moveDirection;

    void Start()
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
            Destroy(gameObject);
        }

        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    // Optional method if you want to set direction from code
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        moveDirection = direction;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
