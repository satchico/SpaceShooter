using UnityEngine;

public class MiniLaser : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, 3f);
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

