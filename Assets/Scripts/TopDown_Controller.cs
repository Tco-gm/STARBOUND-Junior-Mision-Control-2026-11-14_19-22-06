using UnityEngine;

public class TopDown_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    public OxygenSystem oxygenSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement != Vector2.zero)
        {
            rb.linearVelocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}   

