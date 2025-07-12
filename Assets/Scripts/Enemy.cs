using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public GameObject enemyBulletPrefab; 
    public float fireRate = 2f;

    public AudioClip shootSFX;            
    private AudioSource audioSource;      

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        InvokeRepeating(nameof(Shoot), 1f, fireRate);

        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null)
        {
            Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

            if (shootSFX != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSFX); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            if (UIManager.Instance != null)
            {
                UIManager.Instance.AddScore(50); 
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Let PlayerController handle the damage
        }

    }
}







