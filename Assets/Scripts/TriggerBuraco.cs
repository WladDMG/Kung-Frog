using UnityEngine;

public class TriggerBuraco : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem o script PlayerHealth
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(3);
            
        }
    }
}
