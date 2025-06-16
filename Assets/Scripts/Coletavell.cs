using UnityEngine;

public class Coletavell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem o script PlayerHealth
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Tenta aumentar a vida do jogador
            if (playerHealth.IncreaseHealth())
            {
                // Destroi o coletável se a vida foi aumentada
                Destroy(gameObject);
            }
        }
    }
    /* Adicionar o script player health
     
      // Método para aumentar a vida
    public bool IncreaseHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHealthUI();
            Debug.Log("Vida aumentada: " + currentHealth);
            return true; // Retorna verdadeiro se a vida foi aumentada
        }
        else
        {
            Debug.Log("Vida já está no máximo!");
            return false; // Retorna falso se já está no máximo
        }
    }

     */
}
