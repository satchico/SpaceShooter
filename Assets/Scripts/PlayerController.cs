using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioClip shootSFX;
    public AudioClip deathSFX;
    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    private bool isAlive = true;
    private bool isInvincible = false;

    [Header("Respawn Settings")]
    public Vector3 respawnPosition = Vector3.zero; // <--- ADDED: Set this in the Inspector

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!isAlive) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, moveY, 0).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8f, 8f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.5f, 4.5f);
        transform.position = clampedPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            if (shootSFX != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSFX);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isAlive || isInvincible) return;

        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            Die();
            Debug.Log("I'm dying");
        }
    }

    public void Die()
    {
        isAlive = false;

        if (deathSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSFX);
        }

        spriteRenderer.enabled = false;
        playerCollider.enabled = false;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.LoseLife();
        }

        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    
{
    yield return new WaitForSeconds(1f);

    transform.position = respawnPosition;
    isAlive = true;
    isInvincible = true;

    // Enable player visuals and collider
    spriteRenderer.enabled = true;
    playerCollider.enabled = true;

    float blinkDuration = 2f;
    float blinkInterval = 0.2f;
    float elapsed = 0f;

    while (elapsed < blinkDuration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(blinkInterval);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(blinkInterval);
        elapsed += blinkInterval * 2;
    }

    isInvincible = false;
}



    public void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }
}

