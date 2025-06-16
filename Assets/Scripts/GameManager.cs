using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        // Se a inst�ncia j� existe, destr�i o novo objeto para manter uma �nica inst�ncia
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Caso contr�rio, mant�m a inst�ncia e faz o objeto persistir entre cenas
            DontDestroyOnLoad(gameObject);
        }
    } 
    
}
