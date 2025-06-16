using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;           // Velocidade de movimento
    public float jumpForce = 10f;          // For�a do pulo
    public AudioSource jumpSound;          // Som do pulo
    public Animator animator;              // Controlador de anima��es
    public Rigidbody2D rb;

    private bool isJumping = false;        // Controle se o personagem est� pulando
    private float horizontalInput = 0f;    // Valor de entrada para a dire��o horizontal

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }
    // Chamado quando o bot�o de mover para a esquerda � pressionado
    public void PressLeft()
    {
        horizontalInput = -1f;
    }

    // Chamado quando o bot�o de mover para a direita � pressionado
    public void PressRight()
    {
        horizontalInput = 1f;
    }

    // Chamado quando o bot�o de movimento � solto
    public void ReleaseMove()
    {
        horizontalInput = 0f;
    }

    // Chamado quando o bot�o de pulo � pressionado
    public void Jump()
    {
        if (!isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpSound.Play();// Toca o som de pulo
            isJumping = true;
            animator.SetTrigger("Jump");// Ativa a anima��o de pulo
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Anima��o de movimento
        animator.SetFloat("Run", Mathf.Abs(horizontalInput));

        // Muda a orienta��o do sprite com base na dire��o
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
            
    }
    private void FixedUpdate()
    {
        // Aplica o movimento horizontal
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se tocou o ch�o para permitir novo pulo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);  // Reseta o estado de pulo na anima��o
        }
    }
}
