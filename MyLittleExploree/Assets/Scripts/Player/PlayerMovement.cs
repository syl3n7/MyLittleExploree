using System.Runtime.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        var movement = Input.GetAxis("Horizontal1");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        animator.SetFloat("Direita", movement);

        if (Input.GetKey(KeyCode.A))
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

        if (Input.GetButtonDown("Jump1") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}