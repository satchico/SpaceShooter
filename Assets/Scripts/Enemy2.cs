using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 2f;
    public int health = 4;

    public GameObject spreadBulletPrefab;
    public float fireRate = 2f;

    public AudioClip shootSFX;
    private AudioSource audioSource;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        audioSource = GetComponent<AudioSource>();

        if (player != null)
        {
            InvokeRepeating(nameof(SpreadFire), 1f, fireRate);
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Follows player's X position, moves slightly downward
            Vector3 targetPos = new Vector3(player.position.x, transform.position.y - 0.5f, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    void SpreadFire()
    {
        if (spreadBulletPrefab != null)
        {
            Instantiate(spreadBulletPrefab, transform.position, Quaternion.identity);

            if (shootSFX != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSFX);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.AddScore(200); 
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject); 
            TakeDamage(1);             
        }
        else if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die(); 
            }

            Destroy(gameObject); 
        }
    }
}
