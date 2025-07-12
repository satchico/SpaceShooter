using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction = Vector3.down;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, 5f); 
    }

    void Update()
    {
       
        transform.Translate(direction * speed * Time.deltaTime);
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
        }

        Destroy(gameObject);
    }
}







