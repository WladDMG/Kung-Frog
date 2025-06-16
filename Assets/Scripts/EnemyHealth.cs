using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int damageToPlayer = 1; // Dano causado ao jogador
    public Animator animator; // Refer�ncia ao Animator
    public float deathAnimationDuration = 0.5f; // Dura��o da anima��o de morte
    public AudioSource deathSound;
    public Rigidbody2D rb; // Refer�ncia ao Rigidbody2D

    private bool isDying = false; // Para evitar m�ltiplas execu��es de morte
    private bool canDamage = true; // Controle de dano

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
    }
   private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Player"))
         {
            // Jogador levou dano
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);  
                
            }           
            StartCoroutine(EsperaoDano()); // Inicia o tempo de espera
        }

     }
    private IEnumerator EsperaoDano()
    {
        canDamage = false; // Bloqueia o dano
        yield return new WaitForSeconds(1f); // Aguarda 1 segundo
        canDamage = true; // Permite dano novamente
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Jogador matou o inimigo
                Die();

                // Adiciona um impulso para o jogador
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 4f); // Ajuste o valor do impulso se necess�rio
                
            }
        }
    }
    private void Die()
    {
        deathSound.Play();

        // Incrementa a pontua��o do jogador
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.AumentaScore(1); // Adiciona 1 ponto
            }
        }

        // Desativa o componente EnemyPatrol
        EnemyPatrol patrol = GetComponent<EnemyPatrol>();
        if (patrol != null)
        {
            patrol.enabled = false; // Desativa o patrulhamento
        }

        if (isDying) return; // Evita chamar m�ltiplas vezes
        isDying = true;

        // Ativa a anima��o de morte
        animator.SetTrigger("Die");              

        // Espera pela dura��o da anima��o e depois destr�i o objeto
        Destroy(gameObject, deathAnimationDuration);
    }
   
}
