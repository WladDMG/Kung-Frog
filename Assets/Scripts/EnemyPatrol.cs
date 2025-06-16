using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1f;           // Velocidade de movimento do inimigo
    public float patrolDistance = 2f;  // Distância de patrulha

    private Vector2 PontoInicial;        // Ponto inicial da patrulha
    private bool moveDireita = true;   // Direção do movimento

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Define o ponto inicial da patrulha como a posição de início do inimigo
        PontoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // Movimento do inimigo para a direita ou esquerda
        float moveDirection = moveDireita ? 1 : -1;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

        // Verifica se o inimigo atingiu o limite direito da patrulha
        if (moveDireita && transform.position.x >= PontoInicial.x + patrolDistance)
        {
            Flip();
        }
        // Verifica se o inimigo atingiu o limite esquerdo da patrulha
        else if (!moveDireita && transform.position.x <= PontoInicial.x - patrolDistance)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Inverte a direção do movimento
        moveDireita = !moveDireita;

        // Rotaciona o inimigo para que ele "olhe" na direção correta
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
