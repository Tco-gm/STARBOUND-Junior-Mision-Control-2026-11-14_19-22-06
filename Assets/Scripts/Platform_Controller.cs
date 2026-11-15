using UnityEngine;

public class Platform_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        

    }
    private void FixedUpdate()
    {
        Vector2 verticalMovement = new Vector2(0, Input.GetAxis("Vertical"));
        Vector2 horizontalMovement = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (horizontalMovement != Vector2.zero)
        {
            rb.linearVelocity = new Vector2(horizontalMovement.x * speed, rb.linearVelocity.y);
        }
        if (verticalMovement != Vector2.zero && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

}
