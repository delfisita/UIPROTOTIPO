using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControl controls;
    private Vector2 moveInput;
    private Rigidbody rb;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded = true;

    private void Awake()
    {
        controls = new PlayerControl();

        controls.Player.Movimiento.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Movimiento.canceled += _ => moveInput = Vector2.zero;

        controls.Player.Salto.performed += _ => Jump();

        controls.Player.Interact.performed += _ => Interact();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Interact()
    {
        Debug.Log("Interact button pressed!");
        // Implementar lógica de interacción aquí.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
