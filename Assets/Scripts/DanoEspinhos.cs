using UnityEngine;
using System.Collections;

public class DanoEspinhos : MonoBehaviour
{
    public int damageToPlayer = 1; // Dano causado ao jogador
    private bool canDamage = true; // Controle de dano
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
}
