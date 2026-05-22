using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    // 1. A Velocidade
    public float moveSpeed = 5f;

    // 2. As "Caixas" para guardar nossos componentes
    private Rigidbody2D rb;
    private Animator animator; 
    
    // 3. A "Caixa" para guardar a direção do controle
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        // Controla a animação
        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("isWalking", isMoving); 

       // 🟢 NOVIDADE: Envia a direção X e Y para o Animator
        if (isMoving)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }

        // Vira o personagem para a esquerda ou direita
        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  
        }
    }
    // A PEÇA QUE FALTAVA: Movimento Físico
    void FixedUpdate()
    {
        // Empurra o Rigidbody na direção do controle, multiplicado pela velocidade
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}