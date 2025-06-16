using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vida m�xima do jogador
    public int score = 0; // Pontua��o do jogador
    public TextMeshProUGUI scoreText; // Refer�ncia ao texto de pontua��o
    public Image[] healthImages; // Array de imagens para representar a vida
    public Sprite fullHeartSprite; // Sprite para vida cheia
    public Sprite emptyHeartSprite; // Sprite para vida vazia
    public GameObject PainelGameOver; // Painel de Game Over
    public Animator animator;

    public CanvasGroup gameOverCanvasGroup; // Canvas Group do Painel de Game Over

    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida 
        UpdateHealthUI(); // Atualiza as imagens da vida
        UpdateScoreUI(); // Atualiza a pontua��o na UI
        animator = GetComponent<Animator>();

        // Inicializa o painel de Game Over desativado
        if (PainelGameOver != null)
        {
            PainelGameOver.SetActive(false);
        }

        if (gameOverCanvasGroup != null)
        {
            gameOverCanvasGroup.alpha = 0;
        }
    }
  
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
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); 
        }
    }
    public void AumentaScore(int total)
    {
        score += total;
        UpdateScoreUI();
        Debug.Log("Pontua��o: " + score);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida do jogador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        animator.SetTrigger("Hit");
        UpdateHealthUI();

    }

    private void Die()
    {
        Debug.Log("O jogador morreu!");
        // Pausa o jogo
        Time.timeScale = 0;

        // Inicia o fade para o painel de Game Over
        if (PainelGameOver != null && gameOverCanvasGroup != null)
        {
            PainelGameOver.SetActive(true);
            StartCoroutine(FadeInGameOverPanel());
        }
    }
    private IEnumerator FadeInGameOverPanel()
    {
        float fadeDuration = 1.5f; // Dura��o do fade
        float elapsedTime = 0f;

        // Gradualmente aumenta o alpha do CanvasGroup
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime; // Usa tempo n�o escalado
            gameOverCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // Certifica que o alpha est� em 1 no final
        gameOverCanvasGroup.alpha = 1;
    }


    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].sprite = fullHeartSprite; // Mostra vida cheia
            }
            else
            {
                healthImages[i].sprite = emptyHeartSprite; // Mostra vida vazia
            }
        }
    }
    
}
