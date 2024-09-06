using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpForce = 10f;
    private Rigidbody2D rb;
    [SerializeField] public Animator animator;
    private bool animLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x > 223f)
        {
            MovementSpeed = 6f;
            rb.drag = 0f;
            JumpForce = 100f;
        }
        else
        {
            MovementSpeed = 5f;
            JumpForce = 110f;
            rb.drag = 1f;
        }
        var movement = Input.GetAxis("Horizontal2");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        animator.SetFloat("Direita", movement);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animLeft = true;
            animator.SetBool("Esquerda", animLeft);
            animator.SetBool("Parado", animLeft);
        }
        else
        {
            animLeft = false;
            animator.SetBool("Esquerda", animLeft);
            animator.SetBool("Parado", animLeft);
        }

        if (Input.GetButtonDown("Jump2") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}