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
                // Destroi o colet�vel se a vida foi aumentada
                Destroy(gameObject);
            }
        }
    }
    /* Adicionar o script player health
     
      // M�todo para aumentar a vida
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
            Debug.Log("Vida j� est� no m�ximo!");
            return false; // Retorna falso se j� est� no m�ximo
        }
    }

     */
}
