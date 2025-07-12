using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy2 enemy2 = collision.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(1);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            

            Destroy(gameObject); 
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

