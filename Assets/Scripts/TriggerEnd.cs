using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnd : MonoBehaviour
{
    public GameObject PainelFinal;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica se o jogador entrou no trigger
        {
            if (SceneManager.GetActiveScene().name == "Fase1")  // Verifica se estamos na Fase 1
            {
                // Pausa o jogo
                Time.timeScale = 0;
                PainelFinal.SetActive(true);
            }
        }
    }
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
}
