using UnityEngine;
using UnityEngine.InputSystem; // Garante o acesso ao novo sistema

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Mudamos o parâmetro para ler o contexto do Input Action da Unity
    public void OnMove(InputAction.CallbackContext context)
    {
        // Lê o valor do movimento enquanto as teclas são pressionadas
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Aplica o movimento físico no gramado
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}