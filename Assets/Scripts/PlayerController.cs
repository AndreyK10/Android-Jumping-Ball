using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 200f;
    private Rigidbody2D rb;

    public static bool isDead;
    private bool touchedLastFrame = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        isDead = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
                
        if (touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
        }
        else if (!touchedLastFrame && Input.touchCount > 0)
        {
            Jump();
            touchedLastFrame = true;
        }
    }
    
    private void Jump()
    {
        if (!SystemScript.isPaused) rb.velocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isDead = true;
            gameObject.SetActive(false);
            Time.timeScale = 0; 
        }      
    }
}
