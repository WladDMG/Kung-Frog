using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        // Se a instância já existe, destrói o novo objeto para manter uma única instância
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Caso contrário, mantém a instância e faz o objeto persistir entre cenas
            DontDestroyOnLoad(gameObject);
        }
    } 
    
}
