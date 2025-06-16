using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    public GameObject PainelFinal;
    public void LoadMenu()
    {
        // Encontra o objeto com a tag "Manager" e destrói
        GameObject managerObject = GameObject.FindGameObjectWithTag("Manager");
        if (managerObject != null)
        {
            Destroy(managerObject); // Destrói o objeto
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Carrega o menu
                                            
    }

    // Quando o jogador entrar no trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica se o jogador entrou no trigger
        {
            if (SceneManager.GetActiveScene().name == "Fase1")  // Verifica se estamos na Fase 1
            {
                SceneManager.LoadScene("Fase2"); // Carrega a fase 2
                
                // Incrementa a pontuação do jogador
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.AumentaScore(10); // Adiciona 10 pontos
                    }
                }

            }
            else if(SceneManager.GetActiveScene().name == "Fase2")// Verifica se estamos na Fase 2
            {
                // Pausa o jogo
                Time.timeScale = 0;
                PainelFinal.SetActive(true);
            }
        }
    }
}
